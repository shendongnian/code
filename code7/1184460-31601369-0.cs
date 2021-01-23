    public static class MultiResultsetsHelper
        {
            /// <summary>
            ///     Given a data reader that contains multiple result sets, use the supplied object context to serialise the
            ///     rows of data in the result set into our property.
            /// </summary>
            /// <typeparam name="T">Type of the containing object that contains all the various result sets.</typeparam>
            /// <param name="aDbReader">Database reader that contains all the result sets returned from the database.</param>
            /// <param name="aDbContext">Data context associated with the data reader.</param>
            /// <param name="aDataSetTypes">Type for each type to use when we call Translate() on the current result in the data reader.</param>
            /// <param name="aContainedDataSetReturnedTypes">
            ///     List of types in order of which the result sets are contained within the
            ///     data reader. We will serilize sequentially each result set the data reader contains
            /// </param>
            /// <returns>Retuns an object representing all the result sets returned by the data reader.</returns>
            public static T Process<T>(DbDataReader aDbReader, DbContext aDbContext, List<Type> aDataSetTypes, List<Type> aContainedDataSetReturnedTypes) where T : new()
            {
                //What we will be returning
                T result = new T();
    
                // Drop down to the wrapped `ObjectContext` to get access to the `Translate` method
                ObjectContext objectContext = ((IObjectContextAdapter) aDbContext).ObjectContext;
                //Iterate the passed in dataset types as they are in the same order as what the reader contains    
                for (int datasetNdx = 0; datasetNdx < aContainedDataSetReturnedTypes.Count; datasetNdx++)
                {
                    //Advance the reader if we are not looking at the first dataset
                    if (datasetNdx != 0)
                        aDbReader.NextResult();
    
                    //Get the property we are going to be updating based on the type of the class we will be filling
                    PropertyInfo propertyInfo = typeof (T).GetProperties().Single(p => p.PropertyType == aContainedDataSetReturnedTypes[datasetNdx]);
    
                    //Now get the object context to deserialize what is in the resultset into our type
                    MethodInfo method = GetTranslateOverload(typeof (ObjectContext));
                    MethodInfo generic = method.MakeGenericMethod(aDataSetTypes[datasetNdx]);
    
                    //Invoke the generic method which we hvae constructed for Translate
                    object valueForProperty = generic.Invoke(objectContext, new object[] {aDbReader});
    
                    //Finally we update the property with the type safe information
                    propertyInfo.SetValue(result, valueForProperty);
                }
                return result;
            }
    
            /// <summary>
            ///     Internal helper method to get the necessary translate overload we need:
            ///     ObjectContext.Translate<T>(DbReader)
            /// </summary>
            /// <param name="aType">ObjectContext.GetType()</param>
            /// <returns>Returns the method we require, null on error.</returns>
            private static MethodInfo GetTranslateOverload(Type aType)
            {
                MethodInfo myMethod = aType
                    .GetMethods()
                    .Where(m => m.Name == "Translate")
                    .Select(m => new
                                 {
                                     Method = m,
                                     Params = m.GetParameters(),
                                     Args = m.GetGenericArguments()
                                 })
                    .Where(x => x.Params.Length == 1
                                && x.Args.Length == 1
                                && x.Params[0].ParameterType == typeof (DbDataReader)
                    //            && x.Params[0].ParameterType == x.Args[0]
                    )
                    .Select(x => x.Method)
                    .First();
                return myMethod;
            }
        }

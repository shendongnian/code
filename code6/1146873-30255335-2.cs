    /// <summary>
            /// Copy public fields from an instance of the source type TV to an instance of the destination type T.
            ///  A source property will be copied if there is a property in the destination type with the same name.
            /// For instance, TV.Name will be copied to T.Name
            /// </summary>
            /// <typeparam name="T">The destination type</typeparam>
            /// <typeparam name="TV">The source type</typeparam>
            /// <param name="input">The source data</param>
            /// <param name="existingInstance">The instance that we want to copy values to, if it is null a new instance will be created</param>
            /// <returns>An instance of type T</returns>
            public static T CopyFields< TV,T>(TV input, T existingInstance=null)where  T:class where TV:class 
            {
                var sourcePublicFields = typeof (TV).GetProperties();
    
                var instance =existingInstance ?? Activator.CreateInstance<T>();
    
                var destinationPublicFields = typeof(T).GetProperties();
    
                Debug.WriteLine("Copying data from source type {0} to destination type {1}", typeof(TV), typeof(T));
    
                foreach (var field in sourcePublicFields)
                {
                    var destinationField = destinationPublicFields.FirstOrDefault(it => it.Name == field.Name);
                    if (destinationField == null || destinationField.PropertyType != field.PropertyType)
                    {
                        Debug.WriteLine("No Destination Field matched with the source field. Source Field  name {0}, source field type {1} ", field.Name, field.PropertyType);
                        continue;
                    }
    
                    var sourceValue = field.GetValue(input);
                    //Set the value
                    destinationField.SetValue(instance,sourceValue);
    
                }
    
    
                return instance;
            }

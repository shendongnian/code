        private Expression<Func<T, bool>> GetSearchExpression(string targetField, ExpressionType comparison, object value, string enumMethod)
        {
            return (Expression<Func<T, bool>>)MakePredicate(DeQualifyFieldName(targetField, typeof(T)), comparison, value, enumMethod);
        }
        private LambdaExpression MakePredicate(string[] memberNames, ExpressionType comparison, object value, string enumMethod = "Any")
        {
            //create parameter for inner lambda expression
            var parameter = Expression.Parameter(typeof(T), "t");
            Expression left = parameter;
            //Get the value against which the property/field will be compared
            var right = Expression.Constant(value);
            var currentType = typeof(T);
            for (int x = 0; x < memberNames.Count(); x++)
            {
                string memberName = memberNames[x];
                if (FieldExists(currentType, memberName))
                {
                    //assign the current type member type 
                    currentType = SingleLevelFieldType(currentType, memberName);
                    left = Expression.PropertyOrField(left == null ? parameter : left, memberName);
                    //mini-loop for non collection objects
                    if (!currentType.IsGenericType || (!(currentType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                                                         currentType.GetGenericTypeDefinition() == typeof(ICollection<>))))
                        continue;
                    ///Begin loop for collection objects -- this section can only run once
                    //get enum method
                    if (enumMethod.Length < 2) throw new Exception("Invalid enum method target.");
                    bool negateEnumMethod = enumMethod[0] == '!';
                    string methodName = negateEnumMethod ? enumMethod.Substring(1) : enumMethod;
                    //get the interface sub-type
                    var itemType = currentType.GetInterfaces()
                                              .Single(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                              .GetGenericArguments()[0];
                    //generate lambda for single item
                    var itemPredicate = MakeSimplePredicate(itemType, memberNames[++x], comparison, value);
                    //get method call
                    var staticMethod = typeof(Enumerable).GetMember(methodName).OfType<MethodInfo>()
                                                         .Where(m => m.GetParameters().Length == 2)
                                                         .First()
                                                         .MakeGenericMethod(itemType);
                    //generate method call, then break loop for return
                    left = Expression.Call(null, staticMethod, left, itemPredicate);
                    right = Expression.Constant(!negateEnumMethod);
                    comparison = ExpressionType.Equal;
                    break;
                }
            }
            //build the final expression
            var binaryExpression = Expression.MakeBinary(comparison, left, right);
            return Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);
        }
        static LambdaExpression MakeSimplePredicate(Type inputType, string memberName, ExpressionType comparison, object value)
        {
            var parameter = Expression.Parameter(inputType, "t");
            Expression left = Expression.PropertyOrField(parameter, memberName);
            return Expression.Lambda(Expression.MakeBinary(comparison, left, Expression.Constant(value)), parameter);
        }
             
        private static Type SingleLevelFieldType(Type baseType, string fieldName)
        {
            Type currentType = baseType;
            MemberInfo match = (MemberInfo)currentType.GetField(fieldName) ?? currentType.GetProperty(fieldName);
            if (match == null) return null;
            return GetFieldOrPropertyType(match);
        }
        public static Type GetFieldOrPropertyType(MemberInfo field)
        {
            return field.MemberType == MemberTypes.Property ? ((PropertyInfo)field).PropertyType : ((FieldInfo)field).FieldType;
        }
        /// <summary>
        /// Remove qualifying names from a target field.  For example, if targetField is "Order.Customer.Name" and
        /// targetType is Order, the de-qualified expression will be "Customer.Name" split into constituent parts
        /// </summary>
        /// <param name="targetField"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static string[] DeQualifyFieldName(string targetField, Type targetType)
        {
            return DeQualifyFieldName(targetField.Split('.'), targetType);
        }
        public static string[] DeQualifyFieldName(string[] targetFields, Type targetType)
        {
            var r = targetFields.ToList();
            foreach (var p in targetType.Name.Split('.'))
                if (r.First() == p) r.RemoveAt(0);
            return r.ToArray();
        }

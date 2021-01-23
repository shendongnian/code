    //gets the property info of the property with the giving name
         public static PropertyInfo GetPropetyInfo<T>(string name)
            {
                var type = typeof(T);
                var property = type.GetProperty(name);
                return property;
            }
    //Creates an expression thats represents the query
    public static Func<T, bool> GetFilterExpression<T>( string propertyName, object propertyValue)
            {
                var prop = GetPropetyInfo<T>(propertyName);
                if(prop==null)return t=>false;
                var parameter = Expression.Parameter(typeof(T), "t");
                Expression expression = parameter;
                var left = Expression.Property(expression, prop);
                if (prop.PropertyType == typeof(string))
                {
                    var toLower = typeof(string).GetMethods().FirstOrDefault(t => t.Name.Equals("ToLower"));
                    var tlCall = Expression.Call(left, toLower);
                    var right = Expression.Constant(propertyValue.ToString().ToLower());
                    var contains = Expression.Call(tlCall, typeof(string).GetMethod("Contains"), right);
                    var containsCall = Expression.IsTrue(contains);
                    expression = Expression.AndAlso(Expression.NotEqual(left, Expression.Constant(null)), containsCall);                
                }
                else
                {
                    if (prop.PropertyType.ToString().ToLower().Contains("nullable"))
                    {
                        var getValue = prop.PropertyType.GetMethods().FirstOrDefault(t => t.Name.Equals("GetValueOrDefault"));
                        var getValueCall = Expression.Call(left, getValue);
                        var right = Expression.Constant(propertyValue);
                        expression = Expression.Equal(getValueCall, right);
                    }
                    else
                    {                   
                        var value = Convert.ChangeType(propertyValue,prop.PropertyType);
                        var right = Expression.Constant(value);
                        expression = Expression.Equal(left, right);                  
                    }
                }
                return Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[] { parameter }).Compile();
            }

         public class SearchField
        {
            public string Name { get; set; }
            public string @Value { get; set; }
            //public string Operator { get; set; }
            public SearchField(string Name, string @Value)
            {
                this.Name = Name;
                this.@Value = @Value;
                //Operator = "=";
            }
        }
        public class FilterLinq<T>
        {
            public static Expression<Func<T, Boolean>> GetWherePredicate(params SearchField[] SearchFieldList)
            {
                //the 'IN' parameter for expression ie T=> condition
                ParameterExpression pe = Expression.Parameter(typeof(T), typeof(T).Name);
                //combine them with and 1=1 Like no expression
                Expression combined = null;
                if (SearchFieldList != null)
                {
                    foreach (var fieldItem in SearchFieldList)
                    {
                        //Expression for accessing Fields name property
                        Expression columnNameProperty = Expression.Property(pe, fieldItem.Name);
                        //the name constant to match 
                        Expression columnValue = Expression.Constant(fieldItem.Value);
                        //the first expression: PatientantLastName = ?
                        Expression e1 = Expression.Equal(columnNameProperty, columnValue);
                        if (combined == null)
                        {
                            combined = e1;
                        }
                        else
                        {
                            combined = Expression.And(combined, e1);
                        }
                    }
                }
                //create and return the predicate
                if (combined != null) return Expression.Lambda<Func<T, Boolean>>(combined, pe);
                return null;
            }
        }

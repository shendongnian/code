    void Main()
    {
       var predicateBuilder = new PredicateBuilder();
       var keyValuePairs = new List<KeyValuePair>
       {
          new KeyValuePair {Key = "Name", Value = "Test"},
          new KeyValuePair {Key = "Age", Value = "42"},
          new KeyValuePair {Key = "Country", Value = "USA"}
       };
       var predicate = predicateBuilder.Build<Filter>(keyValuePairs);
       var list = new List<Filter>();
       list.Add(new Filter { Name = "Test", Age = "42", Country = "USA"});
   
       list.Where(predicate).Dump();
    }
    public class Filter
    {
       public string Name { get; set; }
       public string Age { get; set; }
       public string Country { get; set; }
    }
    public class KeyValuePair
    {
       public string Key { get; set; }
   
       public string Value { get; set; }
    }
    public class PredicateBuilder
    {
        public Func<T, bool> Build<T>(IEnumerable<KeyValuePair> keyValuePairs)
        {
            var parameter = Expression.Parameter(typeof(T));
      
            var equalExpressions = new List<BinaryExpression>();
            foreach (var keyValuePair in keyValuePairs)
            {
                var propertyInfo = typeof(T).GetProperty(keyValuePair.Key);
      
                var property = Expression.Property(parameter, propertyInfo);
         
                var value = Expression.Constant(keyValuePair.Value, propertyInfo.PropertyType);
         
                var equalExpression = Expression.Equal(property, value);
                equalExpressions.Add(equalExpression);
            }
      
            var expression = equalExpressions.First();
            if (equalExpressions.Count > 1)
            {
                // combine expression with and
                expression = Expression.AndAlso(equalExpressions[0], equalExpressions[1]);
         
                for (var i = 2; i < equalExpressions.Count; i++)
                {
                    expression = Expression.AndAlso(expression, equalExpressions[i]);
                }
            }
      
            var lambda = (Func<T, bool>) Expression.Lambda(expression, parameter).Compile();
            return lambda;
        }
    }

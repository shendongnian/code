       public static Expression<Func<CustomSearchResultItem, bool>> MatchOnMultipleValues(IEnumerable<string> arrayOfIds, string parameter)
        {
            var predicate = PredicateBuilder.True<CustomSearchResultItem>();
            foreach (var id in arrayOfIds)
            {
                // create dynamic expression tree for filter for Enumerable properties (multivalued)
                Expression constant = Expression.Constant(id);
                ParameterExpression parameterExpression = Expression.Parameter(typeof(CustomSearchResultItem), "s");
                Expression property = Expression.Property(parameterExpression, parameter);
                // Call contains method on IEnumerable
                var callExpression = Expression.Call(typeof(Enumerable), "Contains", new[] { typeof(string) }, property, constant);
                predicate = predicate.Or(Expression.Lambda<Func<CustomSearchResultItem, Boolean>>(callExpression, parameterExpression));
            }
            return predicate;
        }
      query = query.Where(ExpressionMatches.MatchOnMultipleValues(arrayIds, Id));

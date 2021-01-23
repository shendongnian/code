    public static IQueryable<T> Relevant<T>(this IQueryable<T> qry, string keyword, bool AllKeywordMustExist = true, char keywordSeparator = ' ')
        {
            var parameter = Expression.Parameter(typeof(T), "relev");
            var objectType = typeof(T);
            var stringProperties = objectType.GetProperties().Where(m => m.PropertyType == typeof(string));
            var keywords = keyword.Split(keywordSeparator)
                .Where(m => !string.IsNullOrEmpty(m))
                .Select(m => m.ToLower())
                .Distinct();
            Expression completeExpression = Expression.Constant(AllKeywordMustExist);
            foreach (var keywordExpression in keywords.Select(m => Expression.Constant(m)))
            {
                Expression keywordCompleteExpression = Expression.Constant(false);
                foreach (var prop in stringProperties)
                {
                    var containExpression = CreatePropertyContainExpression(parameter, prop, keywordExpression);
                    var notNullExpression = Expression.NotEqual(Expression.PropertyOrField(parameter, prop.Name), Expression.Constant(null));
                    var notNullContaintExpression = Expression.Condition(notNullExpression, containExpression, Expression.Constant(false));
                    keywordCompleteExpression = Expression.Or(keywordCompleteExpression, notNullContaintExpression);
                }
                if (AllKeywordMustExist)
                {
                    completeExpression = Expression.And(completeExpression, keywordCompleteExpression);
                }
                else
                {
                    completeExpression = Expression.Or(completeExpression, keywordCompleteExpression);
                }
            }
            return qry.Where(Expression.Lambda<Func<T, bool>>(completeExpression, parameter));
        }
     private static Expression CreatePropertyContainExpression(Expression instance, PropertyInfo instanceProperty, Expression keyword)
        {
            var containMethod = typeof(string).GetMethods().FirstOrDefault(m => m.Name == "Contains" && m.GetParameters().Length == 1);
            var toLowerMethod = typeof(string).GetMethods().FirstOrDefault(m => m.Name == "ToLower" && m.GetParameters().Length == 0);
            var propParam = Expression.PropertyOrField(instance, instanceProperty.Name);
            var tolowerExp = Expression.Call(propParam, toLowerMethod);
            var containExpression = Expression.Call(tolowerExp, containMethod, keyword);
            return containExpression;
        }

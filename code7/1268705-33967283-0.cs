    public class Test
    {
        public Expression<Func<TEntityType, TModelType>> CreateNewStatement<TEntityType, TModelType>(string fields)
        {
            var xParameter = Expression.Parameter(typeof (TEntityType), "o");
            var xNew = Expression.New(typeof (TModelType));
            var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(paramName =>
                {
                    var xOriginal = Expression.Property(xParameter, typeof(TEntityType).GetProperty(paramName));
                    return Expression.Bind(typeof(TModelType).GetProperty(paramName), xOriginal);
                }
                );
            var xInit = Expression.MemberInit(xNew, bindings);
            var lambda = Expression.Lambda<Func<TEntityType, TModelType>>(xInit, xParameter);
            return lambda;
        }
    }

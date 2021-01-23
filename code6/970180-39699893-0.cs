    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllDestinationVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p => p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }
        public static IMappingExpression<TSource, TDestination> IgnoreAllSourceVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var srcType = typeof(TSource);
            foreach (var property in srcType.GetProperties().Where(p => p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal))
            {
                expression.ForSourceMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }
    }

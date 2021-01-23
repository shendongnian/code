    public static class Extensions
    {
        public static IMappingExpression<TSource, TDestination> MapTo<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);
            TypeMap existingMaps = Mapper.GetAllTypeMaps().First(b => b.SourceType == sourceType && b.DestinationType == destinationType);
            string[] missingMappings = existingMaps.GetUnmappedPropertyNames();
            if (missingMappings.Any())
            {
                PropertyInfo[] sourceProperties = sourceType.GetProperties();
                foreach (string property in missingMappings)
                {
                    foreach (PropertyInfo propertyInfo in sourceProperties)
                    {
                        MapToAttribute attr = propertyInfo.GetCustomAttribute<MapToAttribute>();
                        if (attr != null && attr.Name == property)
                        {
                            expression.ForMember(property, opt => opt.ResolveUsing(new MyValueResolve(propertyInfo)));
                        }
                    }
                }
            }
            return expression;
        }
    }
    public class MyValueResolve : IValueResolver
    {
        private readonly PropertyInfo pInfo = null;
        public MyValueResolve(PropertyInfo pInfo)
        {
            this.pInfo = pInfo;
        }
        public ResolutionResult Resolve(ResolutionResult source)
        {
            string key = pInfo.GetValue(source.Value) as string;
            string value = dictonary[key];
            return source.New(value);
        }
    }

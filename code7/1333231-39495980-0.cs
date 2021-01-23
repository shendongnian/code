    public static class PropertyCopy
    {
        public static void Copy<TDest, TSource>(TDest destination, TSource source)
            where TSource : class
            where TDest : class
        {
            var destProperties = destination.GetType().GetProperties()
                .Where(x => !x.CustomAttributes.Any(y => y.AttributeType.Name == PropertyCopyIgnoreAttribute.Name) && x.CanRead && x.CanWrite && !x.GetGetMethod().IsVirtual);
            var sourceProperties = source.GetType().GetProperties()
                .Where(x => !x.CustomAttributes.Any(y => y.AttributeType.Name == PropertyCopyIgnoreAttribute.Name) && x.CanRead && x.CanWrite && !x.GetGetMethod().IsVirtual);
            var copyProperties = sourceProperties.Join(destProperties, x => x.Name, y => y.Name, (x, y) => x);
            foreach (var sourceProperty in copyProperties)
            {
                var prop = destProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
                prop.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }

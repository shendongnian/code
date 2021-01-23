    public void Copy(object Source, object Destination)
    {
        Type sourceType = Source.GetType();
        Type destinationType = Destination.GetType();
        foreach (PropertyInfo sourceProp in sourceType.GetProperties())
        {
            var targetProperty = destinationType.GetProperty(sourceProp.Name);
            if (targetProperty != null &&
                targetProperty.PropertyType.IsArray &&
                typeof (IList<>)
                    .MakeGenericType(targetProperty.PropertyType.GetElementType())
                    .IsAssignableFrom(sourceProp.PropertyType))
            {
                var closedGenericMethod =
                    typeof (Enumerable).GetMethod(nameof(Enumerable.ToArray))
                        .MakeGenericMethod(targetProperty.PropertyType.GetElementType());
                var item = sourceProp.GetValue(Source, null);
                var resultArray = closedGenericMethod.Invoke(null, new[] {item});
                targetProperty.SetValue(Destination, resultArray);
            }
        }
    }

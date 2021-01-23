    using System.Reflection;
    ...
    TDestination Copy<TSource, TDestination>(TSource source)
    where TDestination : new()
    {
        TDestination dest = new TDestination();
        foreach (FieldInfo srcField in typeof(TSource).GetFields())
        {
            foreach (FieldInfo destField in typeof(TDestination).GetFields())
            {
                if (destField.Name == srcField.Name && destField.FieldType == srcField.FieldType)
                {
                    destField.SetValue(dest, srcField.GetValue(source));
                }
            }
        }
        return dest;
    }

    private static Target CopyProperties<Source, Target>(Source source, Target target)
        {
            foreach (var sProp in source.GetType().GetProperties())
            {
                bool isMatched = target.GetType().GetProperties().Any(tProp => tProp.Name == sProp.Name && tProp.GetType() == sProp.GetType() && tProp.CanWrite);
                if (isMatched)
                {
                    var value = sProp.GetValue(source);
                    PropertyInfo propertyInfo = target.GetType().GetProperty(sProp.Name);
                    propertyInfo.SetValue(target, value);
                }
            }
            return target;
        }

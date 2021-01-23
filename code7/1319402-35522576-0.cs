    public static class ObjectExtensions
    {
        public static void AssignPropertiesForm(this object target, object source)
        {
            if (target == null || source == null) throw new ArgumentNullException();
            var targetPropertiesDic = target.GetType().GetProperties().Where(p => p.CanWrite).ToDictionary(p => p.Name);
            foreach (var sourceProp in source.GetType().GetProperties().Where(p => p.CanRead))
            {
                PropertyInfo targetProp;
                if (targetPropertiesDic.TryGetValue(sourceProp.Name, out targetProp))
                {
                    targetProp.SetValue(target, sourceProp.GetValue(source, null), null);
                }
            }
        }
    }

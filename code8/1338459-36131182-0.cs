    public interface IDescription
    {
        string Description { get; }
    }
    public static class EnumEx
    {
        public static T GetValueFromDescription<T, TAttribute>(string description) where TAttribute : Attribute, IDescription
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = (IDescription)Attribute.GetCustomAttribute(field, typeof(TAttribute));
                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
    }

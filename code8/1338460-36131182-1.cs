    public abstract class BaseDescriptionAttribute : Attribute
    {
        public string Description { get; protected set; }
    }
        
    public static class EnumEx
    {
        public static T GetValueFromDescription<T, TAttribute>(string description) where TAttribute : BaseDescriptionAttribute
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = (BaseDescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(TAttribute));

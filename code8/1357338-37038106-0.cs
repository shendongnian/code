    using System.Reflection;
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            EnumDisplayNameAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
                        as EnumDisplayNameAttribute;
            return attribute == null ? value.ToString() : attribute.DisplayName;
        }
    }
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
    public enum Mærke 
    {
        [EnumDisplayName(DisplayName = "Alfa Romeo 5x114")]
        Alfa_Romeo,
    public string mærke { get; set; }
    mærke = Mærke.Alfa_Romeo.DisplayName() 

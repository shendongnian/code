    public abstract class PropertyBase
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
    }
    public class TextProperty : PropertyBase
    {
        public string Value { get; set; }
    }
    public class IntProperty : PropertyBase
    {      
        public int Value { get; set; }
    }

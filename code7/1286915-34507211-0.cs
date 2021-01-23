    void Main()
    {
        typeof(Test).GetProperties().Select(property => new { property.MetadataToken, property.Name, getter = property.GetMethod?.MetadataToken, setter = property.SetMethod?.MetadataToken }).Dump();
        typeof(Test).GetMethods().Select(method => new { method.MetadataToken, method.Name, IsSpecial = (method.Attributes & MethodAttributes.SpecialName) != 0 }).Dump();
    }
    
    public class Test
    {
        public int Value
        {
            get;
            set;
        }
    }

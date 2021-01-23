    public class FooAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public FooAttribute([CallerMemberName] string propertyName = null)
        {
            PropertyName = propertyName;
        }
        public string GetPropertyName()
        {
            return PropertyName;   
        }
    }

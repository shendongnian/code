    public class Parent
    {
        public int SomeProperty { get; set; }
        public FirstLevel FirstLevelProperty { get; set; }
    }
    public class FirstLevel
    {
        public int AnotherProperty { get; set; }
        public SecondLevel SecondLevelProperty { get; set; }
    }
    public class SecondLevel
    {
        public int OneMoreProperty { get; set; }
        [IgnoreDeserializationErrors]
        public int YetAnotherProperty { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreDeserializationErrorsAttribute : Attribute
    {
    }

        [AttributeUsage(AttributeTargets.Class)]
        public class NameAttribute : Attribute
        {
            public NameAttribute(string name)
            {
                Name = name;
            }
    
            public string Name { get; private set; }
        }
        [Name("Class1")]
        public class SomeClass
        {
        }

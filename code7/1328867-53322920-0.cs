         [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
         public class SwaggerParameterAttribute : Attribute
         {
             public SwaggerParameterAttribute(string name, string description)
            {
                Name = name;
                Description = description;
            }
            public string Name { get; private set; }
            public string DataType { get; set; }
            public string ParameterType { get; set; }
            public string Description { get; private set; }
            public bool Required { get; set; } = false;
        }
    

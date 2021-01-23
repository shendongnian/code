    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MyValidationAttribute : Attribute
    {
        public string RegistrationName { get; set; }
        public MyValidationAttribute(string name)
        {
            RegistrationName = name;
        }
    }

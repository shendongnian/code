    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CustomPhoneAttribute : DataTypeAttribute
    {
        public static string MyString = GetValue();
        public CustomPhoneAttribute()
            : base(DataType.PhoneNumber)
        {
        }
        private static string GetValue()
        {
            throw new Exception();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
When using the static keyword, the runtime will need to initialize the type-level values at some point in time before the class itself is instantiated. However, when this happens it causes a crash, because the GetValue code is throwing an exception. That error is going to occur when MVC is looking at the model for data annotations, and it will in turn ignore that attribute (since it failed to be instantiated).
By removing the static keyword, you cause the error to be thrown in your constructor when the annotation is being instantiated, so it's first thrown in your code and the debugger can break on it.

    [AttributeUsage(AttributeTargets.Property)]
    public class FinalizeRequiredAttribute : FinalizeValidationAttribute
    {
        protected override bool IsNotNull(object value)
        {
            return value != null;
        }
    }

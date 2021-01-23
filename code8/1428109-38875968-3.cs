    public class ExceptionBinding : Binding
    {
        public ExceptionBinding() : base()
        {
            ValidationRules.Add(new ExceptionValidationRule());
        }
    }

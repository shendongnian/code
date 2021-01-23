    public class ExceptionBinding : Binding
    {
        public ExceptionBinding()
        {
            ValidationRules.Add(new ExceptionValidationRule());
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
    }

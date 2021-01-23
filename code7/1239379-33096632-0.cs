     public class ExceptionValidationBinding : Binding
    {
        public ExceptionValidationBinding()
        {
            Mode = BindingMode.TwoWay;
            NotifyOnValidationError = true;
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ValidatesOnDataErrors = true;
            ValidationRules.Add(new ExceptionValidationRule());
        }
    }

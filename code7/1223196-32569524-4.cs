    public class CustomValidRule : ValidationRule, IViewModelUIRule
        {
    
            bool _isValid = true;
            public bool IsValid { get { return _isValid; } set { _isValid = value; } }
    
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
    
                int? a = value as int?;
                ValidationResult result = null;
    
                if (a.HasValue)
                {
                    if (a.Value > 0 && a.Value < 10)
                    {
                        _isValid = true;
                        result = new ValidationResult(true, "");
                    }
                    else
                    {
                        _isValid = false;
                        result = new ValidationResult(false, "must be > 0 and < 10 ");
                    }
                }
    
                OnValidationDone();
    
                return result;
            }
    
            private void OnValidationDone()
            {
                if (ValidationDone != null)
                    ValidationDone(this, new ViewModelUIValidationEventArgs(_isValid));
            }
    
            public event ViewModelValidationHandler ValidationDone;
        }
///////////////////////////
     
        public class NegValidRule : ValidationRule, IViewModelUIRule
    {
        bool _isValid = true;
        public bool IsValid { get { return _isValid; } set { _isValid = value; } }
    
        ValidationResult result = null;
    
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int? a = value as int?;
            if (a.HasValue)
            {
                if (a.Value < 0)
                {
                    _isValid = true;
                    result = new ValidationResult(true, "");
                }
                else
                {
                    _isValid = false;
                    result = new ValidationResult(false, "must be negative ");
                }
            }
    
            OnValidationDone();
    
            return result;
        }
    
        private void OnValidationDone()
        {
            if (ValidationDone != null)
                ValidationDone(this, new ViewModelUIValidationEventArgs(_isValid));
        }
    
        public event ViewModelValidationHandler ValidationDone;
    }

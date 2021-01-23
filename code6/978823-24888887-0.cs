        [CustomValidation(typeof(MyModel), "ValidateRange")]
        public double From
        {
            get
            {
                return _from;
            }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    OnPropertyChanged("From");
                    // Validate the other side
                    ValidateProperty("To", _to);
                }
            }
        }
        [CustomValidation(typeof(MyModel), "ValidateRange")]
        public double To
        {
            get
            {
                return _to;
            }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    OnPropertyChanged("To");
                    // Validate the other side
                    ValidateProperty("From", _from);
                }
            }
        }
        private static ValidationResult ValidateRange(ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as MyModel;
            if (model.From > model.To)
            {
                return new ValidationResult("Invalid range");
            }
            return null;
        }

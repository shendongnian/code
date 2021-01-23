        public Validation()
        {
            _Validations = new List<Action<object>>
            {
                ValidateNull,
                ValidateDecimal,
                ValidateIsNumber,
                ValidateRange,
            };
        }
        public bool Validate(Control control, object value)
        {
            try
            {
                _Validations.ForEach(c => c(value));
                return true;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                return false;
            }
        }
        private void ValidateNull(object value)
        {
            if (value == null && !_IsAllowNull)
                throw new Exception("Please provided valid number without a decimal point.");
        }
        private void ValidateRange(object value)
        {
            if (value.ToInt() < _minValue || value.ToInt() > _maxValue)
                throw new Exception("Value should not be greater than " + _maxValue + " or less than " + _minValue);
        }
        private static void ValidateIsNumber(object value)
        {
            if (!value.IsNumber())
                throw new Exception("Please provided valid number without a decimal point.");
        }
        private static void ValidateDecimal(object value)
        {
            if (value.ToString().Contains("."))
                throw new Exception("Decimal value is not allowed");
        }

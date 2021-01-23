       public override bool Validate(Control control, object value)
        {
            if ((value == null && !_IsAllowNull) || !value.IsNumber())
            {
                ErrorText = "Please provided valid number without a decimal point.";
                return false;
            }
           
                if (value.ToString().Contains("."))
                {
                    ErrorText = "Decimal value is not allowed";
                    return false;
                }
                if (value.ToInt() < _minValue || value.ToInt() > _maxValue)
                        {
                            ErrorText = "Value should not be greater than " + _maxValue + " or less than " + _minValue;
                            return false;
                        }
                    
                
            
            return true;
        }

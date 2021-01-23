    public class ContainsValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            string valueString = Convert.ToString(value);
            string validateWithString = Convert.ToString(validateWith);
            return valueString.Contains(validateWithString);
        }
    }
    public class StartWithValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            string valueString = Convert.ToString(value);
            string validateWithString = Convert.ToString(validateWith);
            return valueString.StartsWith(validateWithString);
        }
    }
    public class LengthValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            string valueString = Convert.ToString(value);
            int valueLength = Convert.ToInt32(validateWith);
            return (valueString.Length == valueLength);
        }
    }
    public class LessThanValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            decimal valueDecimal = Convert.ToDecimal(value);
            decimal validateWithDecimal = Convert.ToDecimal(validateWith);
            return (valueDecimal < validateWithDecimal);
        }
    }
    public class MoreThanValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            decimal valueDecimal = Convert.ToDecimal(value);
            decimal validateWithDecimal = Convert.ToDecimal(validateWith);
            return (valueDecimal > validateWithDecimal);
        }
    }
    public class EqualValidator : IValidator
    {
        public bool Validate(object value, object validateWith)
        {
            string valueString = Convert.ToString(value);
            string validateWithString = Convert.ToString(validateWith);
            return (valueString == validateWithString);
        }
    }

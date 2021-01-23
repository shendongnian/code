    public class NumberValidator : IValidator
    {
        public bool Validate(object value)
        {
            return (int) value > 0;
        }
    }
 

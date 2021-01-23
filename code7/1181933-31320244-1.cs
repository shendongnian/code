    public class NumberValidator : IValidator<int>
    {
        public bool Validate(int value)
        {
            return value > 0;
        }
    }
 

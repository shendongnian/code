    public class TrueFalseBoolAttribute: ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            return value is bool;
        }
    }

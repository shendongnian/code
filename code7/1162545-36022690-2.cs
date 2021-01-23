    public class Derived2Validator : AbstractValidator<Derived2>
    {
        public Derived2Validator()
        {
            Include(new BaseValidator());
            Include(new Derived2Validator());
            RuleFor(d => d.Derived1Name).NotNull();
        }
    }

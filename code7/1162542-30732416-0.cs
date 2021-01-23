    public class Base
    {
        public string BaseName { get; set; } 
    }
    public class Derived1 : Base
    {
        public string Derived1Name { get; set; }
    }
    public class BaseValidator<T> : AbstractValidator<T> where T : Base
    {
        public BaseValidator()
        {
            RuleFor(b => b.BaseName).NotNull();
        }
    }
    public class Derived1Validator : BaseValidator<Derived1>
    {
        public Derived1Validator()
        {
            RuleFor(d => d.Derived1Name).NotNull();
        }
    }

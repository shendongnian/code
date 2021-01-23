    public class AValidator: AbstractValidator<A>
    {
        public AValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .When(c => c.Filter == myEnum.ByName);
            RuleFor(a => a.Email)
                .NotEmpty()
                .When(c => c.Filter == myEnum.ByEmail);
        }
    }

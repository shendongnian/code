    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(x => x.DateJoined)
                .NotEmpty().WithMessage("DateJoined is required");
        }
    }
    public class DetailModelValidator : AbstractValidator<DetailModel>
    {
        public DetailModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required");
        }
    }
    

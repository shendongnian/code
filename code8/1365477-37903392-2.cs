    public class ReadAllMenusByApplicationInputValidator : AbstractValidator<ReadAllMenusByApplicationInput> {
        public ReadAllMenusByApplicationInputValidator() {
            RuleFor(x => x.ApplicationName).NotEmpty()
                .WithMessage("The Application Name cannot be blank.");
        }
    }

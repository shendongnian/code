    public class SampleModelValidator : AbstractValidator<SampleModel>
    {
        public SampleModelValidator()
        {
            this.RuleFor(x => x.Step1Validation)
                .NotEmpty()
                .When(x => x.StepNumber >= 1)
                .WithMessage("Step1 Validation Required");
    
            this.RuleFor(x => x.Step2Validation)
                .NotEmpty()
                .When(x => x.StepNumber >= 2)
                .WithMessage("Step2 Validation Required.");
        }
    }

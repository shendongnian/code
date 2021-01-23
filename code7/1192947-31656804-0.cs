    public class ModelValidation : AbstractValidator<Model>
    {
        public ModelValidation()
        {
            RuleFor(x => x.Country).Must(x => x == null || x.Length >= 2);
        }
    }

    public class Validator : AbstractValidator<Master>
    {
        public Validator()
        {
            RuleFor(master => master)
                .Must(CalculateSumCorrectly)
                .When(master => master.Details != null)
                .When(master => master.TotalAmount.HasValue);
        }
        private bool CalculateSumCorrectly(Master arg)
        {
            return arg.TotalAmount == arg.Details.Sum(detail => detail.Amount);
        }
    }

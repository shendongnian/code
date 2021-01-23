    public class IndexViewModel : IValidatableObject
    {
        public Film Film { get; set; }
        public ReviewModel Review { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Film.Genre == Genre.Horror && string.IsNullOrWhiteSpace(Review.Text))
            {
                yield return new ValidationResult(
                    "Please provide a review for this film.",
                    new string[] { nameof(Review.Text) });
            }
        }
    }

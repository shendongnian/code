    public class FindBookingRequestModel : IValidatableObject
    {
        [RegularExpression("[A-Z]+")]
        public string ReservationNumber { get; set; }
        [RegularExpression("...")] // Find a regex online
        public string CreditCardNumber { get; set; }
        [RegularExpression("...")] // Find a regex online
        public string EmailAddress { get; set; }
        [RegularExpression("[A-Z]{3}")]
        public string Origin { get; set; }
        [RegularExpression("[A-Z]{3}")]
        public string Destination { get; set; }
        public DateTime? StartDate { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(this.ReservationNumber) 
                && !string.IsNullOrWhiteSpace(this.Origin))
            {
                yield return new ValidationResult(
                    "You cannot search using Reservation Number and Origin", 
                    new[] { "ReservationNumber", "Origin" });
            }
            if (!string.IsNullOrWhiteSpace(this.EmailAddress) 
                && this.StartDate != null)
            {
                yield return new ValidationResult(
                    "You cannot search using Email Address and Start Date", 
                    new[] { "EmailAddress", "StartDate" });
            }
            yield break;
        }
    }

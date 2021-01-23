    public class FindBookingRequestModel : IValidatableObject
    {
        public string ReservationNumber { get; set; }
        public string CreditCardNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Origin { get; set; }
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

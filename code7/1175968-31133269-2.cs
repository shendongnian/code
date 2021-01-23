        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(this.ReservationNumber) 
                && !string.IsNullOrWhiteSpace(this.CreditCardNumber)
                && this.EmailAddress == null
                && this.Origin == null
                && this.Destination == null
                && this.StartDate == null)
            {
                // OK - Only reservation number and credit card number specified
                yield break;
            }
            /// ...
            yield return new ValidationResult(
                "Invalid combination of search terms");
        }

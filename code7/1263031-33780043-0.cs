    public class OnePhoneRequiredAttribute : ValidationAttribute
    {
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
		var passengerDetails = value as Passenger_Details;
		if (passengerDetails == null)
		{
			// handle depending on your situation
		}
			
		if (string.IsNullOrWhiteSpace(passengerDetails.Phone_Mobile) 
			&& string.IsNullOrWhiteSpace(passengerDetails.Phone_Home) 
			&& string.IsNullOrWhiteSpace(passengerDetails.Phone_Work))
		{	
            return new ValidationResult(Umbraco.GetDictionaryValue("Booking.Validation.OnePhoneRequired"));
        }
		
        return null;
      }
    }

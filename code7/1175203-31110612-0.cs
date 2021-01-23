    public class UserAddress
    {
        [CustomValidation(typeof(UserAddress), "ValidateCityCode")]
        public string CityCode {get;set;}
    }
    public static ValidationResult TestCategoryName(string pNewName, ValidationContext pValidationContext)
    {
        bool IsNotValid = true // should implement here the database validation logic
        if (IsNotValid)
            return new ValidationResult("CityCode not recognized", new List<string> { "CityCode" });
        return ValidationResult.Success;
    }

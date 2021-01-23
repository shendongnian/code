    public class UniqueDoctorNameAttribute : ValidationAttribute
    {
        private readonly string _IdPropertyName;
        public UniqueDoctorNameAttribute(string IdPropertyName)
        {
            _IdPropertyName = IdPropertyName;
        }
        protected override ValidationResult IsValid(object value,
                                                          ValidationContext validationContext)
        {
            string name = value.ToString();
            var property = validationContext.ObjectType.GetProperty(_IdPropertyName);
            if (property != null)
            {
                var idValue = property.GetValue(validationContext.ObjectInstance, null);
                var db = new HospitalEntities();
                var exists = db.Doctors.Any(d => d.DoctorName == name && d.Id!=idValue);
                if (exists )
                       return new ValidationResult("A doctor already exists with that name");
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }

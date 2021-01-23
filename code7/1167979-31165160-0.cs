    [AttributeUsage(AttributeTargets.Property)]
    public abstract class FinalizeValidationAttribute : ValidationAttribute
    {
        public const string DependentProperty = "SaveMode";
        protected abstract bool IsNotNull(object value);
        protected static SaveModeEnum GetSaveMode(ValidationContext validationContext)
        {
            var saveModeProperty = validationContext.ObjectType.GetProperty(DependentProperty);
            if (saveModeProperty == null) return SaveModeEnum.Save;
            return (SaveModeEnum) saveModeProperty.GetValue(validationContext.ObjectInstance);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var saveMode = GetSaveMode(validationContext);
            if (saveMode != SaveModeEnum.SaveFinalize) return ValidationResult.Success;
            return (IsNotNull(value))
                ? ValidationResult.Success
                : new ValidationResult(string.Format("{0} is required when finalizing", validationContext.DisplayName));
        }
    }

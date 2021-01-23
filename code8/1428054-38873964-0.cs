    class CustomLengthValidatorAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLengthValidatorAttribute" /> class.
        /// </summary>
        /// <param name="maxLength">The maximum length.</param>
        public CustomLengthValidatorAttribute(int maxLength)
        {
            this.MaxLength = maxLength;
        }
        /// <summary>
        /// Gets the minimum length.
        /// </summary>
        /// <value>
        /// The minimum length.
        /// </value>
        public int MaxLength { get; private set; }
        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldName = validationContext.MemberName;
            if (Convert.ToString(value).Trim().Length > this.MaxLength)
            {
                return new ValidationResult(this.ErrorMessage = fieldName + " should not be longer than " + this.MaxLength + " character");
            }
            return ValidationResult.Success;
        }
    }

    /// <summary>
            /// Validates current instance properties using Data Annotations.
            /// </summary>
            /// <param name="propertyName">This instance property to validate.</param>
            /// <returns>Relevant error string on validation failure or <see cref="System.String.Empty"/> on validation success.</returns>
            protected virtual string OnValidate(string propertyName)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }
    
                string error = string.Empty;
                var value = GetValue(propertyName);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(1);
                var result = Validator.TryValidateProperty(
                    value,
                    new ValidationContext(this, null, null)
                    {
                        MemberName = propertyName
                    },
                    results);
    
                if (!result)
                {
                    var validationResult = results.First();
                    error = validationResult.ErrorMessage;
                }
    
                return error;
            }

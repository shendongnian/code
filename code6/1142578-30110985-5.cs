    public bool CheckValidation(Type type, string property, object value) {
      PropertyInfo propertyInfo = type.GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
      if (propertyInfo == null) {
         throw new ArgumentException("property");
      }
      var attributes = propertyInfo.GetCustomAttributes();
      foreach (var attribute in attributes) {
         if (attribute is ValidationAttribute) {
            var validationAttribute = (ValidationAttribute)attribute;
            try {
               validationAttribute.Validate(value, string.Empty);
            }
            catch (ValidationException) {
               return false;
            }
         }
      }
      return true;
    }

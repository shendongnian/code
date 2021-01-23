		public static void ValidateViewModel(BaseAuthorizedController controller, ViewModelBase viewModelToValidate)
		{
			var validationContext = new ValidationContext(viewModelToValidate, null, null);
			var validationResults = new List<ValidationResult>();
			Validator.TryValidateObject(viewModelToValidate, validationContext, validationResults, true);
			foreach (var validationResult in validationResults)
			{
				controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
			}
		}

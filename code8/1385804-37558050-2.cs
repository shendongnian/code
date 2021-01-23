	private void SimulateValidation(object model)
	{
		// mimic the behaviour of the model binder which is responsible for Validating the Model
		var validationContext = new ValidationContext(model, null, null);
		var validationResults = new List<ValidationResult>();
		Validator.TryValidateObject(model, validationContext, validationResults, true);
		foreach (var validationResult in validationResults)
		{
			this.controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
		}
	}

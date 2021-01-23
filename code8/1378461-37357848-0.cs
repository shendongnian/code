		public void Add(IValidationResult validationResult)
		{
			if (validationResult == null) { return; }
			foreach (var validationError in validationResult.Errors)
			{
				Add(validationError);
			}
		}

		/// <summary>
		/// Gets the validation error messages for column.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static string GetValidationErrorMessages(this object obj)
		{
			var error = "";
			var errors = obj.GetValidationErrors();
			var validationResults = errors as ValidationResult[] ?? errors.ToArray();
			if (!validationResults.Any())
			{
				return error;
			}
			foreach (var ee in validationResults)
			{
				foreach (var n in ee.MemberNames)
				{
					error += ee + "; ";
				}
			}
			return error;
		}

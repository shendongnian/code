    public class ValidationResult
	{
		public ValidationResult()
		{
			ID = Guid.NewGuid();
		}
		public ValidationResult(bool isValid, string fieldName)
		{
			ID = Guid.NewGuid();
			IsValid = isValid;
			FieldName = fieldName;
		}
		public Guid ID { get; private set; }
		public bool IsValid { get; set; }
		public string FieldName { get; set; }
	}

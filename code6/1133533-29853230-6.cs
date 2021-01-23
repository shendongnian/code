    public class ApiValidationResult
	{
		public List<ApiValidationError> Errors { get; set; }
		public static ApiValidationResult Failure(string errorKey)
		{
			return new ApiValidationResult {Errors = new List<ApiValidationError> {new ApiValidationError(errorKey)}};
		}
        // You can add a bunch of utility methods here
    }
	public class ApiValidationError
	{
		public ApiValidationError()
		{
		}
		public ApiValidationError(string errorKey)
		{
			ErrorKey = errorKey;
		}
        // More utility constructors here
		public string PropertyPath { get; set; }
		public string ErrorKey { get; set; }
		public List<string> ErrorParameters { get; set; }
	}

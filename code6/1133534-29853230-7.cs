    public abstract class ExtendedApiController : ApiController
	{
		protected IHttpActionResult ValidationError(string error)
		{
			return new ValidationErrorResult(ApiValidationResult.Failure(error), this);
		}
        // More utility methods can go here
    }

	public class ValidationErrorResult : NegotiatedContentResult<ApiValidationResult>
	{
		public ValidationErrorResult(ApiValidationResult content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) 
			: base(HttpStatusCode.BadRequest, content, contentNegotiator, request, formatters)
		{
		}
		public ValidationErrorResult(ApiValidationResult content, ApiController controller)
			: base(HttpStatusCode.BadRequest, content, controller)
		{
		}
	}

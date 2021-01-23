	namespace System.Web.Http
	{
		public static class ApiControllerExtensions
		{
			[System.Xml.Serialization.XmlRoot(ElementName = "Error", Namespace = "")]
			public class ErrorResponse
			{
				public string StatusCode { get; set; }
				public string Message { get; set; }
			}
			public static HttpResponseException CreateErrorResponseException(this ApiController controller, HttpStatusCode statusCode, string message)
			{
				ErrorResponse error = new ErrorResponse() 
				{ 
					StatusCode = (int)statusCode + ": " + statusCode.ToString(),
					Message = message 
				};
				HttpResponseMessage responseMessage = controller.Request.CreateResponse(statusCode, error, controller.Request.GetConfiguration());
				return new HttpResponseException(responseMessage);
			}
		}
	}

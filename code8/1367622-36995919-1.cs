        public class ErrorController : ApiController
        {
    		[HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
    		public HttpResponseMessage Handle404()
    		{
    			HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound);
    			message.Content = new ObjectContent(typeof(MessageResponse), Logger.ConditionWarning("Invalid API Request - 404 Not Found"), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
    			return message
    		}
    	}

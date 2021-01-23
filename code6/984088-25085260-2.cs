    public class HandleSerializationErrorAttribute : ExceptionFilterAttribute
    {
       public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is JsonSerializationException)
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                responseMessage.Content = new StringContent(JsonConvert.SerializeObject(context.Exception.Message));
                context.Response = responseMessage;
            }
        }
    }

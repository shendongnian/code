    public class MobileAppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async void OnException( HttpActionExecutedContext actionExecutedContext )
        {
            var sb = new StringBuilder();
            var request = actionExecutedContext.Request;
            sb.Append( $"Url:{request.RequestUri}" );
    
            foreach(var header in request.Headers)
            {
                sb.Append( $"Header:{header.Key} - {String.Join( ", ", header.Value )}" );
            }
    
            if(request.Method == HttpMethod.Post && request.Headers.ContentLength > 0) {
                var content = await request.Content.ReadAsStringAsync();
                sb.Append( $"Content:{content}"); 
            } 
       }
    }

    public class CustomJSONExceptionFilter : ExceptionFilterAttribute
    {    
        public override void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.GetTypedHeaders().Accept.Any(header => header.MediaType == "application/json"))
            {
                var jsonResult = new JsonResult(new { error = context.Exception.Message });
                jsonResult.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
                context.Result = jsonResult;
            }
        }
    }
    
    services.AddMvc(opts => 
    {
        //Here it is being added globally. 
        //Could be used as attribute on selected controllers instead
        opts.Filters.Add(new CustomJSONExceptionFilter());
    });

    app.Use(async (context, next) =>                                           
    {                 
        // if specific condition does not meet
        if (context.Request.Path.ToString().Equals("/foo"))                    
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Some message body.");
        }                                                                   
                                                                               
        await next.Invoke();                                                   
    });       
                                                                 

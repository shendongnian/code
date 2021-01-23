    public IActionResult Get() {
        try {
            IEnumerable<MyEntity> result;
            //...result populated
           return new HttpOkObjectResult(result);
        } catch (Exception ex) {
            //You should handle the error
            HandleError(ex);//the is not an actual method. Create your own.
            //You could then create your own error so as not to leak
            //internal information.
            var error = new 
                { 
                     message = "Enter you user friendly error message",
                     status = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError
                };
            Context.Response.StatusCode = error.status;            
			return new ObjectResult(error);
        }
    }

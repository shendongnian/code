    public List<User> GetAll()
    {
        try
        {
            return _businessLogic.GetAll();
        }
        catch (Exception ex)
        {
            ExceptionHelper.HandleException(ex, _logger, ControllerContext);
            throw;//Added throw to remove compilation error.
        }
    }
    
    class ExceptionHelper {
        public static void HandleException(Exception ex, ILogger _logger, HttpControllerContext controllerContext) {
            _logger.LogError(ex);
            // If possible handle the exception here
            // Code for handling
    
            // Throw it again
            throw new HttpResponseException(
                controllerContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError)
            );
        }
    }

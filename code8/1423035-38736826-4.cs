    class ValdationResult
    {
        public string Message { get; }
        public HttpError Errors { get; }
        public ValdationResult(string message, ModelStateDictionary modelState)
        {
            Message = message;
            Errors = new HttpError(modelState, includeErrorDetail: true).GetPropertyValue<HttpError>(HttpErrorKeys.ModelStateKey);
        }
    }
    ...
    if (!ModelState.IsValid)
    {
        return Content(HttpStatusCode.BadRequest, 
            new ValdationResult("Custom mesage", ModelState));
    }

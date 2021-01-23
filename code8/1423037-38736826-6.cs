    class ValdationResult
    {
        public string Message { get; }
        public HttpError Errors { get; }
        public ValdationResult(string message, ModelStateDictionary modelState)
        {
            Message = message;
            Errors = new HttpError(modelState, includeErrorDetail: true).ModelState;
        }
    }
    ...
    if (!ModelState.IsValid)
    {
        return Content(HttpStatusCode.BadRequest, 
            new ValdationResult("Custom mesage", ModelState));
    }

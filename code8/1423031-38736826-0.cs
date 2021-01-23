    class ValdationResult
    {
        public string Message { get; set; }
        public ModelStateDictionary Errors { get; set; }
    }
    ...
    if (!ModelState.IsValid)
    {
        return Content(HttpStatusCode.BadRequest, new ValdationResult
        {
            Message = "Custom message",
            Errors = ModelState
        });
    }

    public IHttpActionResult Get(Product product)
    {         
         return BadRequest();
    }
    protected override BadRequestResult BadRequest()
    {
         return BadRequest("There was an error with your request", null);
    }
    protected RichBadRequestResponse BadRequest(string message, IEnumerable<string> validationErrors)
    {
         validationErrors = validationErrors ?? new string[0];
         var result = new RichBadRequestResponse(Request)
         {
             modelState = ModelState,
             Message = "There was an error with your request",
             errors = validationErrors.ToArray()
         };
         return result;
     }

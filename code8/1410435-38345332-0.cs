    [HttpGet]
    public HttpResponseMessage GetCustomer()
    {
    var customObject = new { Message="", Parameters="a1,a2"};
    return Request.CreateResponse(HttpStatusCode.BadRequest, CustomObject = customObject);
    }

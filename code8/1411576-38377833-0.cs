    [HttpGet]
    [Route("api/{id}/foo")]
    public HttpResponseMessage foo(int id)
    {
        var response = new ApiResponse();
        response.StatusCode = HttpStatusCode.OK;
        return response;
    }
    [HttpGet]
    [Route("api/{id}/{route}")]
    public HttpResponseMessage bar(int id)
    {
        var response = new ApiResponse();
        response.StatusCode = HttpStatusCode.BadRequest;
        return response;
    }

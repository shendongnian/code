    [Route("X}")]
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.Created, "Bla", typeof(BlaDto))]
    [SwaggerResponse(HttpStatusCode.Conflict, Type = typeof(ErrorResponse))]
    [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
    public IHttpActionResult CreateBla(BlaDto bla)
    {
        BladDto returnObject;
        try
        {
            returnObject = _service.Create(bla);
        }
        catch (DatabaseException databaseException)
        {
            var error = new ErrorResponse { Message = databaseException.Message);
            return Content(HttpStatusCode.BadRequest, error);
        }
        catch (SomeOtherException ex)
        {
            var error = new ErrorResponse { Message = ex.Message);
            return Content(HttpStatusCode.Conflict, error);
        }
        return Ok(returnObject);     
    }
    public class ErrorResponse
    {
        string Message { get; set; }
    }

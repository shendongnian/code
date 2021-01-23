    [Authorize]
    [HttpGet, Route("api/GetJobType/{id}")]
    public IHttpActionResult GetJobType(int? id)
    {
       try
       {
         var model = new JobsModel();
         return Ok(model.GetJobType(id.Value));
       }
       catch
       {
         return InternalServerError();
       }
    }

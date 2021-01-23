    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> CreateNewApplication(dynamic data)
    {
        if (data == null)
        {
            return BadRequest("data was empty");
        }
        try
        {
            var doc = await _applicationResource.Save(data);
            return Ok(doc.Id); //code hits this point and 'returns'
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("")]
    public JsonResult Post([FromBody]List<Models.Event> events)
    {
        try
        {
            _context.Events.AddRange(events);
            return Json(true);
        }
        catch
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
        }
    }

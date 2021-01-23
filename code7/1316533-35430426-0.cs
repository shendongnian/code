    [HttpPost("")]
    public JsonResult Post([FromBody]PostData data)
    {
        return Json("Test");
    }
    class PostData
    {
       public Log_Header LogHeader { get; set; }
       public Log_Detail LogDetail { get; set; }
         
    }

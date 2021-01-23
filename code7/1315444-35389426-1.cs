    [HttpPut]
    [Route("adminAPI/sponsors/{sponsorID:long}/Enable")]
    public HttpResponseMessage EnableSponsor([FromBody]Model model, [FromUri] Int64 sponsorID)
    {
        HttpResponseMessage ret = null;
        // does stuff and populates the response
        return ret;
    }

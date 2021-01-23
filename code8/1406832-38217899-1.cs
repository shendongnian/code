    [HttpGet]
    [Route("api/NewHotelData")]
    public HttpResponseMessage Get([FromUri] string ids)
    {
        var separated = ids.Split(new char[] { ',' });
        List<int> parsed = separated.Select(s => int.Parse(s)).ToList();
    }

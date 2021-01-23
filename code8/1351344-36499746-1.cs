    [HttpPost]
    [Route("api/TestJsonInput")]
    public string TestJsonInput1()
    {
        string JsonContent = Request.Content.ReadAsStringAsync().Result;
        return JsonContent;
    }

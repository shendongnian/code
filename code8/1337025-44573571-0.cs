    [HttpPost]
    public async Task<IActionResult> CreateApp([FromQuery]string userId)
    {
        string appDefinition = await new StreamReader(Request.Body).ReadToEndAsync();
        var newAppJson = JObject.Parse(appDefinition);
    ...

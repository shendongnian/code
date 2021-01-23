    public async Task<ActionResult> Get(int Id)
    {
        var centre = new Centre {CentreId = Id};
        centre = (await CentreService.Get(centre)).Data;
        var jc = JsonConvert.SerializeObject(centre);
        Response.ContentType = "application/json";
        return Content(jc)
    }

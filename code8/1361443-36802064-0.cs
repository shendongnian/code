    public IHttpActionResult PostNewCharacter([FromBody] string value)
    {
    	var list = new List<string>();
    	list.Add("something");
    	list.Add("something else");
    	return Json(list);
    }

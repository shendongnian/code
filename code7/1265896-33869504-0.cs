    [HttpPost]
    [Route("Stuff/Ids/")]
    public void PostStuff(List<int> Ids)
	{
        if(!ModelState.IsValid)
			throw new Exception("ModelState is not valid.");
		// Carry on...
	}

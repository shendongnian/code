    [HttpPost]
    public async Task<IActionResult> Update([FromBody]  CollectionSettings model)
    {
         // to do : Do something useful.
         return new JsonResult(new {Status = "Success"});
    }

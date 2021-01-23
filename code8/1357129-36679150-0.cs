    [HttpGet]
    [Route("users/useraddoredit/{id?}")]
    public async Task<IActionResult> UserEdit(string id)
    {
      if(string.isNullorEmpty(id))
      {
        return View();
      }
      return View(vm);
    }

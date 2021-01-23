    [Route("~/{cate}")]
    [Route("{lang}/{cate}")]
    public IActionResult Index(string lang, string cate)
    {
       return View();
    }

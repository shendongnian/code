    [HttpPost]
    public ActionResult Upload(HttpContext context)
    {
      for (int files = 0; files < context.Request.Files.Count; files++)
     {
     // Code here
     }
    }

    [HttpPost]
    public ContentResult SomeAction(string value1, string value2)
    {
      if(String.IsNullOrEmpty(value1) || String.IsNullOrEmpty(value2)) { throw new Exception("World not found."); }
      return Content("something");
    }

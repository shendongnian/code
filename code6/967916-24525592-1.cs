    [HttpPost]
    public ActionResult Create (ModelClass newItem)
    {
      int newItemId = -1;
      string message = "";
      bool createdOk = false;
      try{
         newItemId = CreateNewItemInDatabase(newItem); //example - you'd need a proper implementation!
      }
      catch (Exception ex)
      {
         message = "Error: " + ex.Message;
      }
      return Json(new {ErrMessage = message, Ok = createdOk, newItemId = newItemId}) //example. Any object would do.
    }

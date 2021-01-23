    [HttpPost]
    [ValidateInput(false)]
    public ActionResult method_name(FormCollection collection){
      var inputValue = collection.GetValue("name").AttemptedValue;
      return RedirectToAction("method_name", "controller", inputValue);
    }

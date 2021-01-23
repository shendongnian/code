    [HttpPost]
    public ActionResult Index(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            // The decryption of the id parameter has succeeded, you can use model.Id here
        }
        else
        {
            // Decryption failed or the id parameter was not provided: act accordingly
        }
    }

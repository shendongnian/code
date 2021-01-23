    public ActionResult ViewA()
    {
        var sizeChoicesFromDb = "40,41,42,43"; // get from db
        var myModel = new MyViewModel
        {
            SizeChoices = sizeChoicesFromDb .Split(',').ToList().ConvertAll(Int32.Parse)
        };
        return View(myModel);
    }

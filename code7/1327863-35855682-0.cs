    public ActionResult Request(RequestType request)
    {
        var model = new MyModel
        {
            RequestType = request
        };
        return View(model);
    }

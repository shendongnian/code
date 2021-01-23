    public ActionResult MyAction()
    {
        ViewData["MT"] =YourIEnumerableCollection() //Code to get the collection
        var model = new MyModel();
        return view(model);
    }

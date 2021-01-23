    public ActionResult MyAction()
    {
      ViewData["MT"] =YourIEnumerableCollection() //Code to get the collection
      return view(model);
    }

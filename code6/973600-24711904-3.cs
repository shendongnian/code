    [HttpPost]
    public ActionResult Rs(List<MyModel> model)
    {
      foreach(MyModel item in model)
      {
        if(item.Accepted) {.. // do something
        else if (item.NotAccepted) { .. // do something else
        else {.. // do another thing
      }
    }

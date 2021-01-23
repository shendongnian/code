    [HttpPost]
    public void UploadDocument(State model)
    {
       if(ModelState.IsValid)
       {
          string state = model.State;
       }
    }

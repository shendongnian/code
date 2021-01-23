    public ActionResult DoLogic()
    {
      //var Results = ?? as The ENum
     
      switch(Results)
      {
        PrefixSearch.SearchResults.CustomerFound:
          model.PageToRender = "_CustomerPrefixInfo";
        // etc etc
      }    
      return View(model);
    }

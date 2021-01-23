    private string TheException = "" ;
    public Task GetRecipeListAsync()
    {
      TheException = "" ;
      Task result = Task.Run(async () => 
      {
        try 
        {  
          //I get the page using WebRequest and WebResponse in the same way as above
          ...
         }
         catch (Exception Ex)  
      }
      if (TheException!="") MessageBox.show(TheException) ; 
      // or Throw an exception with
      return result ; 
    }

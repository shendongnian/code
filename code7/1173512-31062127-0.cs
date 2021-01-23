    private void TopLevelMethod()
    { 
        List<string> errors=new List<string>() ;
        if (!SomeMethod(errors)) { /* Log/report errors/display to user etc. */ }
    }
    
    private bool SomeMethod(List<string> errors)
    {
        return TestPartA(errors) && TestPartB(errors) && TestPartC(errors) && TestPartD(errors);
    }
    
    private bool TestPartA(List<string> errors)
    {
      bool result = true ;
      try 
      {
        // Do some testing...
        if (somethingBadHappens) { result=false; errors.Add("The error that happens"); }
      }
      catch (Exception ex) { errors.Add("Error in TestPartA: "+Ex.Exception.Message.ToString()) ; }
      return result ;
    }
       
    private bool TestPartB(List<string> errors)
    {
      bool result = true ;
      // Do some testing...
      if (somethingBadHappens) { result = false ; errors.Add("The error that happens"); }
      return result ;
    }
   

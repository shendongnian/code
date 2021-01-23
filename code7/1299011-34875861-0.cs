    public void FirstFunction()
    {
       ....
       try
       {
            SecondFunction();
       }
       catch(Exception ex)
       {
            // here is text of exception being thrown in SecondFunction
            string errorText = ex.Message; 
       }
    }

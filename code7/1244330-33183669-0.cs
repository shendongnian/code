     protected void test ()
     {
         try
         {
             throw new Exception("HI");  // Exception message passed from constructor
         }
         catch (Exception ex) 
         { 
             lblerror.Text = ex.Message;
         }
    }

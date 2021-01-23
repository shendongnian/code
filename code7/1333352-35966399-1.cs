    public void Button_Click1(object sender, EventArgs e)
    {
         try
         {
             TestClass cl = new TestClass();
             cl.Test();
         }
         catch(CustomException custEx)
         {
             //this for your Bussines logic exception
             //write your message
         }
         catch(DivideByZeroException div)
         {
              //this for divide by zero exception
              //write message
         }
         //you can catch all other exception like this but I don't advice you to do that
         catch(Exception ex)
         {
             //for this to working properly, this catch should be under all of others(last priority)
         }
    
    }

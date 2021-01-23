    static async Task TestItem()
    {
        while (true) {
         try 
         {
             await Task.Delay(2500);
             throw new Exception("My Test Error");
         } 
         catch (Exception) 
         {
            //TODO for you: handle
         }
        }
    }

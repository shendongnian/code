    public async Task<Dictionary<string, double>> myAsyncFunction()
    {
         await Task.Delay(1);  //to make it async
         //Wait till all the OnPageFinished events have fired. 
         while (myDictionary.Any(x=>x.Value == 0) == true)
         {
             //there are still websites which have not fully loaded. 
         }
         return myDictionary;
    }

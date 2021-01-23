    async public void Processor() //see the "async" keyword
    {
       //SETTING UI COMPONENTS 
       foreach (string url in Urls)
       {
            await Task.Run(() =>
            {
                 //.... WORKING THAT TAKES TIME
            });
            
            //MODIFYING UI COMPONENTS
       }
    }

    public async Task<List<string>> Get(){
       var task1 = GetTAsync(url1);
       var task2 = GetTAsync(url2);
       var tasks = new List<Task>{task1, task2};
       //instead of calling Task.WhenAll and wait until all of them finishes and which messes me up when one of them throws, i got the following code to process each as they complete and handle their exception (if they throw too)
       foreach(var task in tasks)
       {
          try{
           var result = await task; //this may throw so wrapping it in try catch block
           //use result here
          }
          catch(Exception e) // I would appreciate if i get more specific exception but, even HttpRequestException as some indicates couldn't seem working so i am using more generic exception instead. 
         {
            //deal with it 
         }
       } 
    }

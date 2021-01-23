     ServicePointManager.DefaultConnectionLimit =20;
     var client = new HttpClient();
    
     var blockOptions=new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism=10};
     var emailBlock=new ActionBlock<SendEmailParametersModel>(async arameters=>
         {
             var watch=new Stopwatch();
             var content = new StringContent(parameters, Encoding.UTF8, "application/json");
             var response = await client.PostAsync(url, content);
             _log.Info(..);
             watch.Restart();
             var responseString = await response.Result.Content.ReadAsStringAsync();
             _log.Info(...);
     });

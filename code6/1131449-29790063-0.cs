    async Task SomeMethod()
    {
       try
       {
           .....
           Run();
           var result = await GetResult();
       }
       catch(OperationCancelledException)
       {
           // handle cancelled operation
       }
    }

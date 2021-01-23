    public async Task<boolean> IsIntegerIGetFromRemoteServerPostitiveAsync(){
          int result = await GetSomeIntegerAsync();
          Console.WriteLine('Resuming execution of the method');
          return i>0;
    }

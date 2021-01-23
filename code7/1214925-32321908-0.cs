      async Task<int> DoWorkA(int arg1)
      {
         var serviceResult = await service.CallAsync(arg1);
         return ParseServiceResult(serviceResult);
      }
      async Task DoWorkB() { ... await SomeAsync(1,2,3);...}
      var tasks = new[] {DoWorkA(42), DoWorkB() }; 
      await Task.WhenAll(tasks);
      var resultOfA = tasks[0].Result;

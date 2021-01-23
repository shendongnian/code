      // use "async Task(...)" as equivalent of "void DoWorkA(...)".
      async Task<int> DoWorkAAsync(int arg1)
      {
         var serviceResult = await service.CallAsync(arg1);
         return ParseServiceResult(serviceResult);
      }
      async Task<int> DoWorkBAsync() 
      { 
         ... await SomeAsync(1,2,3);...
         return someResult;
      }
      var tasks = new[] {DoWorkAAsync(42), DoWorkBAsync() }; 
      await Task.WhenAll(tasks);
      var resultOfA = tasks[0].Result;

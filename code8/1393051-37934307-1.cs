      using System.Threading.Tasks;
    
      var task = Task.Run(() => SomeMethod(input));
      if (task.Wait(TimeSpan.FromSeconds(10)))
         return task.Result;
      else
         throw new Exception("Timed out");

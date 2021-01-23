      public async void wait() //here is the problem
      {                          
        int waitingTime = await getWaitingTime();
        Console.Writeline("string.Format("Done with {0}: {1} ms", this.Id, waitingTime));
      }
      private Task<int> getWaitingTime()
      {     
         return new Task<int>.Run(() =>
         {  
            int waitingTime = new Random().Next(2000);
            System.Threading.Thread.Sleep(waitingTime);
            return waitingTime;
         });
      }

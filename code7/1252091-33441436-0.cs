      private readonly IList<BackgroundWorker> workers = new List<BackgroundWorker>();
      private void Run()
      {
         var worker1 = new BackgroundWorker();
         worker1.DoWork += (sender, args) => Thread.Sleep(1000);
         worker1.RunWorkerCompleted += (sender, args) => this.CheckThreads();
         
         var worker2 = new BackgroundWorker();
         worker2.DoWork += (sender, args) => Thread.Sleep(1000);
         worker2.RunWorkerCompleted += (sender, args) => this.CheckThreads();
         lock (this.workers)
         {
            this.workers.Add(worker1);
            this.workers.Add(worker2);
         }
         worker1.RunWorkerAsync();
         worker2.RunWorkerAsync();
      }
      private void CheckThreads()
      {
         lock (this.workers)
         {
            if (this.workers.All(w => !w.IsBusy))
            {
               Console.WriteLine("All workers completed");
            }
         }
      }

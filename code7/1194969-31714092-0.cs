         void Main()
         {
            var tasks = Enumerable.Range(0, 500).Select(e =>	System.Threading.Tasks.Task.Run(() => DoWork(e)));
	         System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
         }
         public void DoWork(int i)
         {
	         Console.WriteLine(i.ToString());
         }

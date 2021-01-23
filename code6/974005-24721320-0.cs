    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingFromIntert bar = new DoSomethingFromIntert();  
            bar.Verify(@"id1", true);
            bar.Verify(@"id2", false);
            bar.Verify(@"id3", true);
            bar.Verify(@"id4", false);
            bar.Verify(@"id5", true);
            bar.Verify(@"id6", false);
            Console.ReadLine();
        }
    }
    public class DoSomethingFromIntert
    {
        BlockingCollection<VerifySomethingFromInternet> toProcess = new BlockingCollection<VerifySomethingFromInternet>();
        ConcurrentBag<VerifySomethingFromInternet> workinglist = new ConcurrentBag<VerifySomethingFromInternet>();
        public DoSomethingFromIntert()
        {
            //init four consumers you may choose as many as you want
            ThreadPool.QueueUserWorkItem(DoesWork);
            ThreadPool.QueueUserWorkItem(DoesWork);
            ThreadPool.QueueUserWorkItem(DoesWork);
            ThreadPool.QueueUserWorkItem(DoesWork);
        }
        public void Verify(string param, bool flag)
        {
            //add to the processing list
            toProcess.TryAdd(new VerifySomethingFromInternet(param, flag));
        }
        bool RemoveIFTrueFromInternet(VerifySomethingFromInternet vsfi)
        {
            Console.WriteLine(String.Format("Identification : {0} - Thread : {1}", vsfi.Identification, Thread.CurrentThread.ManagedThreadId));
            // Do some blocking work at internet
            return vsfi.IsRemovable;
        }
        private void DoesWork(object state)
        {
            Console.WriteLine(String.Format("total : {0}", toProcess.Count));
            foreach (var item in toProcess.GetConsumingEnumerable())
            {
                //do work
                if (!RemoveIFTrueFromInternet(item))
                {
                    //add to list if working
                    workinglist.TryAdd(item);
                }
                //no need to remove as it is removed from the list automatically
            }
            //this line will only reach after foo.CompleteAdding() and when items are consumed(verified)
            Console.WriteLine(String.Format("total : {0}", toProcess.Count));
        }
    }

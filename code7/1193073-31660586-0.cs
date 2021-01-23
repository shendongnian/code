    static void Main(string[] args)
    {
        //// Your initialization code
       if (devfound)
       {
            //// Device found, prepare for task
            var t1 = Task.Factory.StartNew(() =>
            {
                //// Task body
            });
            t1.Wait();
       }
    }

    public static void Main()
    {
       var rwl = new ReaderWriterLock();
       rwl.AcquireWriterLock(1000);
       var t1 = new Thread(() =>
       {
          try
          {
             rwl.AcquireReaderLock(1000);
             Console.WriteLine("Acquired lock successfully");
          }
          catch (ApplicationException)
          {
             Console.WriteLine("Time out");
          }
       });
       t1.Start();
       t1.Join();
       rwl.ReleaseWriterLock();
    }

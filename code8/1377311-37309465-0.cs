    using System;
    using System.Printing;
    namespace ConsoleApplication6
    {
    class Program
    {
        static void Main(string[] args)
        {
            var server = new LocalPrintServer();
            IPrintQueue testablePrintQueue = new RealPrintQueue(server);
            IPrintSystemJobInfo  printSystemJobInfo = testablePrintQueue.AddJob();
            var result = printSystemJobInfo.IsBlocked;
            Console.WriteLine(result);
        }
        public interface IPrintSystemJobInfo
        {
             bool IsBlocked { get; }
        }
        public interface IPrintQueue
        {
            IPrintSystemJobInfo AddJob();
        }
        public class RealPrintQueue:IPrintQueue
        {
            private PrintQueue _queue; 
            public RealPrintQueue(LocalPrintServer server)
            {
                _queue = server.DefaultPrintQueue;
            }
            public IPrintSystemJobInfo AddJob()
            {
                return new RealPrintSystemJobInfo(_queue);
            }
        }
        public class RealPrintSystemJobInfo: IPrintSystemJobInfo
        {
            private PrintSystemJobInfo job;
            public RealPrintSystemJobInfo(PrintQueue queue)
            {
                job = queue.AddJob();
            }
            public bool IsBlocked
            {
                get { return job.IsBlocked; }
            }
        }
    }

    public class Program
    {
        
        public static void Main(string[] args)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
            Console.ReadLine();
        }
        [DebuggerNonUserCode] //Comment this line to see the difference.
        private static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new InvalidOperationException(); 
        }
        private static void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debugger.Break();
        }
    }

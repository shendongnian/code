    class Program
    {
        static List<string> UserCollection = null;
        static void Main(string[] args)
        {
            FillUserList("Hello", "World");
            Console.ReadLine();
        }
        public static void FillUserList(string machineName, string groupName)
        {
            var worker = new BackgroundWorker();
            var temporaryUserCollection = new List<string>();
            worker.DoWork += (s, ea) => { YourLongRunningTask(machineName, groupName, temporaryUserCollection); };
            worker.RunWorkerCompleted += (s, ea) => { UserCollection = temporaryUserCollection; Console.WriteLine("Loaded."); };
            worker.RunWorkerAsync();
            // I'm writing to the console, but you should show
            // some sort of loading indicator (spinner, "please wait" dialog, progress bar, etc.) in this line
            Console.WriteLine("Loading...");
        }
        public static void YourLongRunningTask(string machineName, string groupName, List<string> userCollection)
        {
            // Paste your current FillUserList code here
            Thread.Sleep(5000);
            userCollection.Add("A");
            userCollection.Add("B");
            userCollection.Add("C");
        }
    }

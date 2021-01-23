    class Foo
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit); 
           // Do your stuffs
        }
    
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Full path of exe";
            p.StartInfo.Arguments = "arguments";
            p.Start();
        }
    }

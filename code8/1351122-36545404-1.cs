    {
        static void Main(string[] args)
        {
            Console.WriteLine("Internet Explorer: ");
            (new List<browserlocation.URLDetails>(browserlocation.InternetExplorer())).ForEach(u =>
            {
                Console.WriteLine("[{0}]\r\n{1}\r\n", u.Title, u.URL);
            });
          
            Console.Write("\n press enter to view Chrome current tab URL");
            Console.ReadLine();
            foreach (Process process in Process.GetProcessesByName("chrome"))
            {
                string url = browserlocation.GetChromeUrl(process);
                if (url == null)
                    continue;
                Console.WriteLine("CH Url for '" + process.MainWindowTitle + "' is " + url);
                Console.ReadLine();
            } 
        }
    }

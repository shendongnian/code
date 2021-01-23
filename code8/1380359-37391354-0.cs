    static class Program
        {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // check if network is connected
            if (!NetworkInterface.GetIsNetworkAvailable() || CurrentIpRestricted(GetLocalIPAddress()))
            {
                // Exit Code Access Denied
                Environment.Exit(5);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        // you need to think about, if you want a WhiteList or a Blacklist and configure the code
        private static HashSet<string> Whitelist = new HashSet<string>();
        private static bool CurrentIpRestricted(string local)
        {
            return !Whitelist.Contains(local);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }

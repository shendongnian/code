    public class MyClass
    {
        private const int SW_RESTORE = 9;
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool BringWindowToTop(IntPtr hWnd);
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        public static string GetWebPageTitle(string url)
        {
            // Create a request to the url
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            // If the request wasn't an HTTP request (like a file), ignore it
            if (request == null) return null;
            // Use the user's credentials
            request.UseDefaultCredentials = true;
            // Obtain a response from the server, if there was an error, return nothing
            HttpWebResponse response = null;
            try { response = request.GetResponse() as HttpWebResponse; }
            catch (WebException) { return null; }
            // Regular expression for an HTML title
            string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
            // If the correct HTML header exists for HTML text, continue
            if (new List<string>(response.Headers.AllKeys).Contains("Content-Type"))
                if (response.Headers["Content-Type"].StartsWith("text/html"))
                {
                    // Download the page
                    WebClient web = new WebClient();
                    web.UseDefaultCredentials = true;
                    string page = web.DownloadString(url);
                    // Extract the title
                    Regex ex = new Regex(regex, RegexOptions.IgnoreCase);
                    return ex.Match(page).Value.Trim();
                }
            // Not a valid HTML page
            return null;
        }
        public static void BringToFront(string title)
        {
            try
            {
                if (!String.IsNullOrEmpty(title))
                {
                    IEnumerable<IntPtr> listPtr = null;
                    // Wait until the browser is started - it may take some time
                    // Maximum wait is (200 + some) * 100 milliseconds > 20 seconds
                    int retryCount = 100;
                    do
                    {
                        listPtr = FindWindowsWithText(title);
                        if (listPtr == null || listPtr.Count() == 0)
                        {
                            Thread.Sleep(200);
                        }
                    } while (--retryCount > 0 || listPtr == null || listPtr.Count() == 0);
                    if (listPtr == null)
                        return;
                    foreach (var hWnd in listPtr)
                    {
                        if (IsIconic(hWnd))
                            ShowWindow(hWnd, SW_RESTORE);
                        SetForegroundWindow(hWnd);
                    }
                }
            }
            catch (Exception)
            {
                // If it fails at least we tried
            }
        }
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size++ > 0)
            {
                var builder = new StringBuilder(size);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }
            return String.Empty;
        }
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();
            EnumWindows(delegate(IntPtr wnd, IntPtr param)
            {
                if (GetWindowText(wnd).Contains(titleText))
                {
                    windows.Add(wnd);
                }
                return true;
            }, IntPtr.Zero);
            return windows;
        }
        [STAThread]
        public static int Main(string[] args)
        {
            try
            {
                if (args.Count() == 0)
                    return 0;
                // ...
                // Wait until the user's desktop is inactive (outside the scope of this solution)
                // ...
                String url = args[0];
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                // ...
                // Get the path to the default browser from registry, and create a StartupInfo object with it.
                // ...
                process.StartInfo = startInfo;
                process.Start();
                try
                {
                    process.WaitForInputIdle();
                }
                catch (InvalidOperationException)
                {
                    // if the process exited then it passed the URL on to the other browser process.
                }
                String title = GetWebPageTitle(url);
                if (!String.IsNullOrEmpty(title))
                {
                    BringToFront(title);
                }
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
    }

    private static List<IEContainer> Current_IEs;
    private static SHDocVw.ShellWindows shellWindows;
    static void Main(string[] args)
    {
        Current_IEs = new List<IEContainer>();
   		shellWindows = new SHDocVw.ShellWindowsClass();
   		shellWindows.WindowRegistered+=new SHDocVw.DShellWindowsEvents_WindowRegisteredEventHandler(shellWindows_WindowRegistered);
   		shellWindows.WindowRevoked+=new SHDocVw.DShellWindowsEvents_WindowRevokedEventHandler(shellWindows_WindowRevoked);
            
        while (true)
            Console.ReadLine();
    }
    // THIS EVENT IS FIRED WHEN THE BROWSER IS JUST ABOUT THE NAVIGATE TO A WEBSITE
    private static void browser_BeforeNavigate2(object a,ref object b,ref object c,ref object d,ref object e,ref object f,ref bool g)
  	{
        try
        {
            bool adbar = (bool)a.GetType().InvokeMember("AddressBar", System.Reflection.BindingFlags.GetProperty, null, a, null);
            if (adbar)
                Console.WriteLine(b);
        }
        catch (Exception)
        {
        }
    }
    // THIS EVENT IS FIRED WHEN THE A NEW BROWSER IS CLOSED
  	private static void shellWindows_WindowRevoked(int z)
  	{
        if (Current_IEs.Exists(x => x.Cookie == z))
        {
            Console.WriteLine("Browser close: " + z);
            Current_IEs.Remove(Current_IEs.Find(x => x.Cookie == z));
        }
  	}
  
  	// THIS EVENT IS FIRED WHEN THE A NEW BROWSER IS OPEN
    private static void shellWindows_WindowRegistered(int z)
    {
        string filnam;
        foreach (SHDocVw.InternetExplorer ie in shellWindows)
        {
            filnam = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                
            if (filnam.Equals("iexplore"))
            {
                if (!Current_IEs.Exists(x => x.IE == ie))
                {
                    try
                    {
                        bool adbar = (bool)ie.GetType().InvokeMember("AddressBar", System.Reflection.BindingFlags.GetProperty, null, ie, null);
                        if (adbar)
                        {
                            Current_IEs.Add(new IEContainer { Cookie = z, IE = ie });
                            Console.WriteLine("Browser open: " + z);
                            ie.NavigateComplete2 += browser_NavigateComplete2;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
    static void browser_NavigateComplete2(object pDisp, ref object URL)
    {
        try
        {
            bool adbar = (bool)pDisp.GetType().InvokeMember("AddressBar", System.Reflection.BindingFlags.GetProperty, null, pDisp, null);
            if (adbar)
                Console.WriteLine(URL);
        }
        catch (Exception)
        {
        }
    }
    class IEContainer
    {
        public int Cookie { get; set; }
        public SHDocVw.InternetExplorer IE { get; set; }
    }

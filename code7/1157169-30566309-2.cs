    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    const string InternetExplorerClass = "IEFrame";
    static void Main()
    {
        var windowHandle = new IntPtr(0);
    
        //Find internet explorer instance
        windowHandle = FindWindow(InternetExplorerClass, null);
    
        if (!windowHandle.Equals(IntPtr.Zero))
        {
            //create filter to improve search speed
            var localizedControlType = new PropertyCondition(
                AutomationElement.LocalizedControlTypeProperty,
                "tab item");
    
            //get all elements in internet explorer that match our filter
            var elementCollection =
                AutomationElement.FromHandle(windowHandle)
                    .FindAll(TreeScope.Subtree, localizedControlType);
    
            //iterate through search results
            foreach (AutomationElement item in elementCollection)
            {
                Console.WriteLine(item.Current.Name);
            }
        }
        else
        {
            Console.WriteLine("Internet explorer not found");
        }
    
        Console.ReadLine();
    }

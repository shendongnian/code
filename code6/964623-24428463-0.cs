    class Program
    {
        static void Main(string[] args)
        {
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Subtree, (sender, e) =>
                {
                    AutomationElement src = sender as AutomationElement;
                    if (src != null)
                    {
                        Console.WriteLine("Class : " + src.Current.ClassName);
                        Console.WriteLine("Title : " + src.Current.Name);
                        Console.WriteLine("Handle: " + src.Current.NativeWindowHandle);
                    }
                });
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);
        }
    }

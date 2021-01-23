    class Program
    {
        static void Main(string[] args)
        {
            AutomationElement main = AutomationElement.FromHandle(GetDesktopWindow());
            foreach(AutomationElement child in main.FindAll(TreeScope.Children, PropertyCondition.TrueCondition))
            {
                AutomationElement window = GetEdgeCommandsWindow(child);
                if (window == null) // not edge
                    continue;
    
                Console.WriteLine("title:" + GetEdgeTitle(child));
                Console.WriteLine("url:" + GetEdgeUrl(window));
                Console.WriteLine();
            }
        }
    
        public static AutomationElement GetEdgeCommandsWindow(AutomationElement edgeWindow)
        {
            return edgeWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                new PropertyCondition(AutomationElement.NameProperty, "Microsoft Edge")));
        }
    
        public static string GetEdgeUrl(AutomationElement edgeCommandsWindow)
        {
            var adressEditBox = edgeCommandsWindow.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "addressEditBox"));
    
            return ((TextPattern)adressEditBox.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(int.MaxValue);
        }
    
        public static string GetEdgeTitle(AutomationElement edgeWindow)
        {
            var adressEditBox = edgeWindow.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "TitleBar"));
    
            return adressEditBox.Current.Name;
        }
    
        [DllImport("user32")]
        public static extern IntPtr GetDesktopWindow();
    }

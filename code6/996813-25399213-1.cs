    namespace ConsoleApplication1
    {
        class Program
        {
            // EWS Microsoft.Exchange.WebServices.Data.Folder
            private static object _historyFolder;
    
            static void Main(string[] args)
            {
                _historyFolder = GetHistroyFolder(null) ?? CreateHistortFolder(null);
    
                Console.WriteLine(_historyFolder == null);
            }
    
            public static object GetHistroyFolder(object service)
            {
                return new object();
                //if found the folder I want - return it , otherwise returns null
            }
    
            public static object CreateHistortFolder(object service)
            {
                return null;
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += MyResolveEventHandler;
    
        }
    
    
        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Console.WriteLine("Try resolving: " + args.Name);
            return null;
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
                if(args.Length > 0 && !String.isNullOrEmpty(args[0]);
                   Cef.Initialize(new CefSettings() { UserAgent = args[0] });
            }
        }

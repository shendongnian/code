        static void Main(string[] args)
        {
            string pkgLocation;
            Package pkg;
            Application app;
            DTSExecResult pkgResults;
            MyEventListener eventListener = new MyEventListener();
            
            pkgLocation =@"D:\MIS Reports\TERA DATA\Daily_CBASQ1_Loading.dtsx";
            app = new Application();
            pkg = app.LoadPackage(pkgLocation,eventListener);
            pkgResults = pkg.Execute();
            Console.WriteLine(pkgResults.ToString());
            Console.ReadKey();
        }
    }
    class MyEventListener : DefaultEvents
    {
        public override bool OnError(DtsObject source, int errorCode, string subComponent,
               string description, string helpFile, int helpContext, string idofInterfaceWithError)
        {
            // Output Error Message
            Console.WriteLine("Error in {0}/{1} : {2}", source, subComponent, description);
            return false;
        }
    }

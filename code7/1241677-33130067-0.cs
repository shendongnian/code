      public class LoaderCallBackHelper: Java.Lang.Object,ILoaderCallbackInterface
        {
            public void OnManagerConnected(int p0)
            {
                switch (p0)
                {
                    case LoaderCallbackInterface.Success: 
                        System.Console.WriteLine("Succes");
                        break;
                    default:
                        this.OnManagerConnected(p0);
                        break;
                }
            }
            public void OnPackageInstall(int p0, IInstallCallbackInterface p1)
            {
                p1.Install();
                System.Console.WriteLine(p1.PackageName);
            }  

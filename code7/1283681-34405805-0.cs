    var info = new ProcessStartInfo ( path , arguments )
               {
                    Domain = processConfiguration.Domain ,
                    Password = password ,
                    UserName = processConfiguration.UserName ,
                    RedirectStandardOutput = true ,
                    UseShellExecute = false ,
                    CreateNoWindow = true
               } ;
    System.Diagnostics.Process proc = new System.Diagnostics.Process () ;
                               proc.StartInfo = info ;
                               proc.Start () ;

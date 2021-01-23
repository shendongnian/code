    using System.Diagnostics;
            namespace AppA
            {
                class StartProgram
                {
                    static void Main(string[] args)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo("AppB.exe"); //you can allso provide full path of the exe if both these exe's are not present on the same folder
                        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        
                        Process.Start(startInfo);
        
                        startInfo.Arguments = string.Join(" ",args);
        
                        Process.Start(startInfo);
                    }
                }
            }

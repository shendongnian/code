    using System;
    using System.IO;
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                //string varibale for hostilfe
                var HOSTFILE = "";
                //set to color c => red
                Console.ForegroundColor = ConsoleColor.Red;
                //Get OperatingSystem information from the system namespace.
                var osInfo = Environment.OSVersion;
                //Determine the platform.
                if (osInfo.Platform == PlatformID.Win32NT)
                { 
                    //is windows NT
                    HOSTFILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"system32\drivers\etc\hosts");
                }
                else
                {
                    //is no windows NT
                    HOSTFILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "hosts");
                }
                //print hostfile
                Console.WriteLine(HOSTFILE);
				//wait or run your program
                Console.ReadLine();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using RDotNet;
    using Microsoft.Win32;
    using System.IO;
    
    namespace Con_R2
    {
        class Program
        {
    
            static string  rPath = "";
            static void Main(string[] args)
            {
    
                SetupPath(); // current process, soon to be deprecated
                using (REngine engine = REngine.CreateInstance("RDotNet"))
                {
                    engine.Initialize(); // required since v1.5
    
                    REngine.SetDllDirectory(rPath);
    
                    foreach (string path in engine.Evaluate(".libPaths()").AsCharacter())
                    {
                        Console.WriteLine(path);
                    }
                    engine.Evaluate(".libPaths(C:\\Program Files\\R\\R-3.3.1\\library)");
                    //engine.Evaluate("source('c:/Program Files/R/R-3.3.1/bin/load_forecast_grid.r')");
                    engine.Evaluate("source('c:/Program Files/R/R-3.3.1/bin/testcmd.r')");
                    Console.ReadLine();
                    Console.ReadKey();
                }          
            }
    
            public static void SetupPath(string Rversion = "R-3.3.1")
            {
                var oldPath = System.Environment.GetEnvironmentVariable("PATH");
                rPath = System.Environment.Is64BitProcess ?
                                       string.Format(@"C:\Program Files\R\{0}\bin\x64", Rversion) :
                                       string.Format(@"C:\Program Files\R\{0}\bin\i386", Rversion);
    
                if (!Directory.Exists(rPath))
                    throw new DirectoryNotFoundException(
                      string.Format(" R.dll not found in : {0}", rPath));
                var newPath = string.Format("{0}{1}{2}", rPath,
                                             System.IO.Path.PathSeparator, oldPath);
                System.Environment.SetEnvironmentVariable("PATH", newPath);
            }
    
    
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using RDotNet;
    using Microsoft.Win32;
    namespace Con_R
    {
        class Program
        {
            static void Main(string[] args)
            {
                string rhome = System.Environment.GetEnvironmentVariable("R_HOME");
                if (string.IsNullOrEmpty(rhome))
                    rhome = @"C:\Program Files\R\R-3.3.1";
                System.Environment.SetEnvironmentVariable("R_HOME", rhome);
                System.Environment.SetEnvironmentVariable("PATH", System.Environment.GetEnvironmentVariable("PATH") + ";" + rhome + @"binx64");
                // Set the folder in which R.dll locates.
                //REngine.SetDllDirectory(@"C:Program FilesRR-2.12.0bini386″);
                REngine.SetDllDirectory(@"C:\Program Files\R\R-3.3.1\bin\x64");
                // REngine e = REngine.CreateInstance("test", new[] { "" });
                using (REngine engine = REngine.CreateInstance("RDotNet",  "-q" ))  // quiet mode
                {
                
                    foreach (string path in engine.Evaluate(".libPaths()").AsCharacter())
                    {
                        Console.WriteLine(path);
                    }
                    engine.Evaluate(".libPaths(C:\\Program Files\\R\\R-3.3.1\\library)");
                    engine.Evaluate("source(D:\\R\\Script\\load_forecast_grid.r)");
                    Console.ReadLine();
                }
            }
        }
    }

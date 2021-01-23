    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace Test
    {
        class Program
        {
            [DllImport("kernel32", SetLastError = true)]
            static extern IntPtr LoadLibrary(string lpFileName);
    
            static void Main(string[] args)
            {
                if (Environment.Version.Major >= 4)
                {
                    string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"..\Microsoft.NET\Framework\v2.0.50727");
                    folder = Path.GetFullPath(folder);
                    LoadLibrary(Path.Combine(folder, "vjsnativ.dll"));
                }
    
                // Now you can use J# in newer .NET versions
            }
        }
    } 

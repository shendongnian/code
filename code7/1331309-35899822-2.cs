    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Codeception
    {
        class Program
        {
            static void Main(string[] args)
            {
                var code = getcode("Program.cs");
    
                Console.WriteLine(code);
            }
    
            private static string getcode(string filename)
            {
                using (var sr = new StreamReader(typeof(Program).Assembly.GetManifestResourceStream("Codeception." + filename)))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

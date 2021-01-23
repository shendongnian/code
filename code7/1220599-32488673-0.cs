    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace XSD2CS
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter xsd file: ");
                string xsdFile = Console.ReadLine();
    
                if (!File.Exists(xsdFile)) {
                    Console.WriteLine("Error. File doesn't exists.");
                    Environment.Exit(1);
                }
    
                Process p = new Process();
                p.StartInfo.FileName = "XSD.exe";
                p.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin";
                p.StartInfo.Arguments = "/c " + xsdFile;
    
                p.Start();
            }
        }
    }

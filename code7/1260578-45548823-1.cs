    using System;
    using Microsoft.Win32;
    using RegistryUtils;
    
    namespace ConsoleApplicationRegistry
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var dateModified = RegistryHelper.GetDateModified(RegistryHive.LocalMachine, @"SYSTEM\Software\Microsoft");
                if(dateModified.HasValue)
                    Console.WriteLine("Key Last Modified Date: {0}", dateModified.Value);
                else
                    Console.WriteLine("Error... Try again.");
            }
        }
    }

    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication
    {
        class Program
        {
            private enum Settings
            {
                ScreenDefinitionsFileC,
                ScreenDefinitionsFileH
            };
    
            static void Main(string[] args)
            {
                var settings= new Dictionary<Settings, string>()
                {
                    {Settings.ScreenDefinitionsFileC, "Setting 1"},
                    {Settings.ScreenDefinitionsFileH, "Setting 2"}
                };
    
    
                foreach (var setting in settings)
                {
                    Console.WriteLine("{0} {1}", setting.Key, setting.Value);
                }
    
                Console.ReadKey(true);
            }
        }
    }

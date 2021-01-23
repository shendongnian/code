    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization; // Contains JavaScriptSerializer from System.Web.Extensions
    
    namespace Tester
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                deserialize();
            }
            
            public static void deserialize()
            {
    
                string jsonRaw = @"[
                {
                    'A': 'asdasd',
                    'B': 'asdasd',
                    'C': '43543543',
                    'D': 'fdgdfgt54654',
                    'E': '54tg54g54g'
                },
                {
                    'A': '45tg54tg54g',
                    'B': 'g45erg45g',
                    'C': 'rhtfg4hg4g',
                    'D': 'hdfhg45yg',
                    'E': 'fgh45yg45'
                },
                {
                    'A': 'trh4yh45yg',
                    'B': 'gy45g4554egt5',
                    'C': '54hg4rg45g',
                    'D': 'gtrg45g',
                    'E': 'fdg54g45g545454'
                }
            ]";
    
                List<RootObject> rObjects = new JavaScriptSerializer().Deserialize<List<RootObject>>(jsonRaw);
                foreach (var o in rObjects)
                {
                    Console.WriteLine(o.A + ", " + o.B + ", " + o.C + ", " + o.D + ", " + o.E);
                }
            }
        }
    
        public class RootObject
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }
        }
    }

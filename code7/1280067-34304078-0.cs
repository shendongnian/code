    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>() {
                   {123, new List<string>() {"Do this", "Do that"}},
                   {234, new List<string>() {"Do that", "Do something"}},
                   {345, new List<string>() {"Do something"}},
                   {567, new List<string>() {"Do anything"}}
                };
                List<string> results = dict[123];
            }
        }
    }

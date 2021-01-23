    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                input = string.Format("<Root>{0}</Root>", input);
                XElement root = XElement.Parse(input);
            }
        }
    }
    ​

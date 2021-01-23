    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = @"(</?)(\w+:)";
                string output = Regex.Replace(input, pattern, "$1");
                StringReader reader = new StringReader(output);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
            }
        }
    }
    ​

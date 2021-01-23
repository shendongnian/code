    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace TBParser
    {
       class Program
       {
        static void Main(string[] args)
        {
            string fileName = @"C:shpereCompare3.txt";
            List<string> Names = new List<string>();
            List<string> Value = new List<string>();
            using (StreamReader fileReader = new StreamReader(fileName))
            {
                string fileLine;
               
                while (!fileReader.EndOfStream)
                {
                    fileLine = fileReader.ReadLine();
                    if (fileLine.StartsWith("Name"))
                    {
                        Names.Add(fileLine.Substring(21));
                    }
                    if (fileLine.StartsWith("Center"))
                    {
                        string[] fileSplit = fileLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Value.Add(fileSplit[1]);
                    }
                }
                string outputString = "";
                for (int i = 0;i < Names.Count; i++)
                {
                    outputString += Names[i] + " = " + Value[i] + "\r\n";
                }
                System.IO.File.WriteAllText(@"C:Test.txt", outputString);
            }
        }
    }
}

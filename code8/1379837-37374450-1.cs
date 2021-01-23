    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<List<int>> data = LoadLevelData(FILENAME);
            }
            public static List<List<int>> LoadLevelData(string filename)
            {
                List<List<int>> data = new List<List<int>>();
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Element("Root");
                string array = root.Value;
                string[] rows = array.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in rows)
                {
                    string line = row.Replace("[", "");
                    line = line.Replace("]", "");
                    List<int> newRow = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                    data.Add(newRow);
                }
                return data;
            }
        }
    }

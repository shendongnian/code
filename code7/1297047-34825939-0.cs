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
            static void Main(string[] args)
            {
                string input1 = "a";
                List<XElement> results1 = ProcessData(input1);
                string input2 =
                    "A.Property_A_B.Property_B_Int\n" +
                    "A.Property_A_B.Property_B_String\n" +
                    "A.Property_A_C.Property_C_D.Property_D_Double";
                List<XElement> results2 = ProcessData(input2);
                string input3 =
                    "a.a.a.a.a.a.a\n" +
                    "a.a.a.a.a.a.b\n" +
                    "a.a.a.b";
                List<XElement> results3 = ProcessData(input3);
            }
            static List<XElement> ProcessData(string input)
            {
                StringReader reader = new StringReader(input);
                string inputLine = "";
                List<List<string>> properties = new List<List<string>>();
                while ((inputLine = reader.ReadLine()) != null)
                {
                    properties.Add(inputLine.Split(new char[] { '.' }).ToList());
                }
                List<XElement> results = Recursive(properties);
                return results;
            }
            static List<XElement> Recursive(List<List<string>> input)
            {
                List<XElement> results = new List<XElement>();
                string parent = input[0][0];
                
                Dictionary<string, List<List<string>>> dict = input.GroupBy(m => m.FirstOrDefault(), n => n)
                    .ToDictionary(m => m.Key, n => n.Select(p => p.Skip(1).ToList<string>()).ToList());
                foreach (string key in dict.Keys)
                {
                    List<List<string>> subChilds = dict[key];
                    //List<XElement> subElements = new List<XElement>();
                    for (int i = subChilds.Count() - 1; i >= 0;  i--)
                    {
                        if (subChilds[i].Count() == 0)
                        {
                            subChilds.RemoveAt(i);
                        }
                    }
                    List<XElement> child = null;
                    if (subChilds.Count() > 0)
                    {
                        child = Recursive(subChilds);
                        //elements.Add(child);
                        
                    }
                    results.Add(new XElement(key, child));
                }
                return results;
            }
        }
    }

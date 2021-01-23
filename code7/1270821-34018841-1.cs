    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static Regex r = new Regex(@"(&#[xX]?[A-Fa-f\d]+;)|[^\w\s\/\;\&\.@-]", RegexOptions.Compiled);
    
            static void Main(string[] args)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                var xmls = new StringBuilder("<Nodes>");
                for(int i = 0;i<35000;i++)
                {
                    xmls.Append(@"<Node>
                                      <Title>Lorem~~~~</Title>
                                      <Country>Ipsum!</Country>
                                   </Node>");
                }
                xmls.Append("</Nodes>");
    
                var doc = XDocument.Parse(xmls.ToString());
    
                sw.Start();
                foreach(var element in doc.Descendants("Title").Where(ContainsBadCharacters))
                {               
                    element.Value = r.Replace(element.Value, "$1");
                }
                foreach (var element in doc.Descendants("Country").Where(ContainsBadCharacters))
                {
                    element.Value = r.Replace(element.Value, "$1");
                }
                sw.Stop();
    
                var saveFile = new FileInfo(Path.Combine(Assembly.GetExecutingAssembly().Location.Substring(0, 
                    Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\")), "test.txt"));
                if (!saveFile.Exists) saveFile.Create();
    
                doc.Save(saveFile.FullName);
                Console.WriteLine(sw.Elapsed);
                Console.Read();
            }
    
            static bool ContainsBadCharacters(XElement item)
            {
                return r.IsMatch(item.Value);
            }
        }
    }

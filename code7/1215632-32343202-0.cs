>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                   "<pre> <td><b>product file number </b> 7269</td>  </pre>" +
                   "<pre> <td><b>product file number </b> 7562</td> </pre>" +
                   "<pre> <td><b>product file number </b> 7502</td> </pre>";
                //add root tag around data so you have only one root tag
                input = string.Format("<Root>{0}</Root>", input);
                XElement root = XElement.Parse(input);
                List<int> numbers = root.Descendants("pre").Select(x => int.Parse(x.Element("td").Nodes().Skip(1).Take(1).FirstOrDefault().ToString())).ToList();
     
            }
     
        }
      
    }

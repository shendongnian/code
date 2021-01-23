    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "<td class=\"actual\"><span class=\"revised worse\" title=\"Revised From 107.2%\">106.4%</span></td>";
                XElement element = XElement.Parse(input);
                string value = element.Descendants("span").Select(x => (string)x).FirstOrDefault();
     
            }
            
        }
    }

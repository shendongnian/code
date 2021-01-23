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
            static void Main(string[] args)
            {
                string input = 
                   "<Root>" +
                    "<branch name=\"TigerDrop\">" +
                       "<milestones>" +
                         "<milestone name=\"BETA1\"></milestone>" +
                         "<milestone name=\"BETA2\"></milestone>" +
                       "</milestones>" +
                    "</branch>" +
                    "<branch name=\"EagleDrop\">" +
                       "<milestones>" +
                         "<milestone name=\"RFLD\"></milestone>" +
                         "<milestone name=\"RFVD\"></milestone>" +
                       "</milestones>" +
                    "</branch>" +
                    "<branch name=\"LionDrop\">" +
                       "<milestones>" +
                         "<milestone name=\"WIP2\"></milestone>" +
                         "<milestone name=\"WIP3\"></milestone>" +
                       "</milestones>" +
                    "</branch>" +
                    "</Root>";
                XDocument elements = XDocument.Parse(input);
                string parent = "TigerDrop";
                List<XElement> result = elements.Descendants("branch").Where(item => item.Attribute("name").Value == parent).Descendants("milestone").ToList();
            }
        }
    }
    ​

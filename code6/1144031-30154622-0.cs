    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string XMLdefinition = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                string input = 
                    "<table id=\"ReportTab\">" +               
                       "<tr >" +
                           "<td rowspan=\"2\">header_1</td>" +
                           "<td colspan=\"2\">header_2</td>" +
                           "<td colspan=\"3\">header_3</td>" +
                       "</tr>" +
                       "<tr>" +
                           "<td>header_2.1</td>" +
                           "<td>header_2.2</td>" +
                           "<td>header_3.1</td>" +
                           "<td>header_3.2</td>" +
                           "<td>header_3.3</td>" +             
                       "</tr>" +
                       "<tr>" +
                           "<td>12653</td>" +
                           "<td>323</td>" +
                           "<td>87</td>" +
                           "<td>546</td>" +
                           "<td>346</td>" +
                           "<td>463</td>" +              
                       "</tr>" +
                   "</table>";
                string XML = XMLdefinition + input;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XML);
                doc.Save(FILENAME);
            }
        }
    }
    ​

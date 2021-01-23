    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<Root xmlns:yahoo=\"abc\" xmlns:yweather=\"def\">" +
                    "<query yahoo:count=\"1\" yahoo:created=\"2016-03-31T06:43:49Z\">" +
                      "yahoo:lang=\"en-US\"><results>" +
                        "<channel>" +
                          "<item>" +
                            "<yweather:condition>" +
                              "code=\"28\" date=\"Thu, 31 Mar 2016 08:00 AM SAST\" temp=\"58\" text=\"Mostly Cloudy\"/>" +
                            "</yweather:condition>" +
                          "</item>" +
                        "</channel>" +
                      "</results>" +
                    "</query>" +
                    "</Root>";
                XDocument doc = XDocument.Parse(xml);
                string innertext = doc.Descendants().Where(x => x.Name.LocalName == "condition").Select(y => y.Value).FirstOrDefault();
                string pattern = "\\s?(?'name'[^=]+)=\"(?'value'[^\"]+)\"";
                MatchCollection matches = Regex.Matches(innertext, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine("Name : {0}, Value : {1}", match.Groups["name"].Value, match.Groups["value"].Value);
                }
                Console.ReadLine();
            }
        }
    }

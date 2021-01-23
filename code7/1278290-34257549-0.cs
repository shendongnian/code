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
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                    "<!DOCTYPE SomeDocTypeIdidntPutThere>\n" +
                    "<TestingFacility id=\"MACHINE2_1970-01-01T11_22_33\" version=\"1970-01-01\">\n" +
                    "<Program>\n" +
                      "<Title>Fancy Title</Title>\n" +
                      "<Steps>136</Steps>\n" +
                    "</Program>\n" +
                    "<Info type=\"Start\" value=\"2070-01-01T11:22:33\" />\n" +
                    "<Info type=\"LotMoreOfThem\" value=\"42\" />\n";
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                StreamReader reader = new StreamReader(stream);
                string inputLine = "";
                string timeStr = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if(inputLine.StartsWith("<Info type=\"Start\""))
                    {
                        string pattern = "value=\"(?'time'[^\"]+)";
                        timeStr = Regex.Match(inputLine, pattern).Groups["time"].Value;
                        break;
                    }
                }
                DateTime time;
                if (timeStr.Length > 0)
                {
                    time = DateTime.Parse(timeStr);
                }
            }
        }
    }
    ​

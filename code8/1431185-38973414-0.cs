    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("current").Select(x => new {
                   temperature = x.Elements("temperature").Select(y => new {
                       value = (decimal)y.Attribute("value"),
                       min = (decimal)y.Attribute("min"),
                       max = (decimal)y.Attribute("max"),
                       unit = (string)y.Attribute("unit")
                   }).FirstOrDefault(),
                   humidity = x.Elements("humidity").Select(y => new
                   {
                       value = (decimal)y.Attribute("value"),
                       unit = (string)y.Attribute("unit")
                   }).FirstOrDefault(),
                   pressure = x.Elements("pressure").Select(y => new
                   {
                       value = (decimal)y.Attribute("value"),
                       unit = (string)y.Attribute("unit")
                   }).FirstOrDefault()
                }).FirstOrDefault();
            }
         }
    }

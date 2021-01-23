    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace Demo
    {
        internal class Program
        {
            [STAThread]
            private static void Main()
            {
                var doc = XDocument.Load("D:\\TEST\\INPUT.XML"); // Assume you have the XML file stored here.
                // Convert existing entries to a dictionary of dictionaries: 
                // So dict[date][key] == count
                var entries = doc.Elements("entrys").Elements("entry");
                var existing = entries.ToDictionary
                (
                    item => item.Attribute("date").Value, 
                    item => item.Descendants("key").ToDictionary
                    (
                        key => (int)key.Attribute("id"),
                        key => (int)key
                    )
                );
                // SAMPLE DATA: Add new items for specific date.
                string date = "2015_08_31";
                var newData = new Dictionary<int, int>();
                newData[99]  = 10;
                newData[300] = 20;
                addEntriesForDate(date, existing, newData);
                // Store back to XML.
                var xd = new XDocument(new XDeclaration("1.0", "UTF-8", ""),
                    new XElement("entrys", existing.Select(kvp => 
                        new XElement("entry", new XAttribute("date", kvp.Key), kvp.Value.Select(key =>
                            new XElement("key", new XAttribute("id", key.Key), key.Value 
                 ))))));
                xd.Save("D:\\TEST\\OUTPUT.XML");
            }
            private static void addEntriesForDate(string date, Dictionary<string, Dictionary<int, int>> existing, Dictionary<int, int> newData)
            {
                if (!existing.ContainsKey(date))
                    existing[date] = new Dictionary<int, int>();
                var data = existing[date];
                foreach (var entry in newData)
                {
                    if (data.ContainsKey(entry.Key))
                        data[entry.Key] += entry.Value;
                    else
                        data[entry.Key] = entry.Value;
                }
            }
        }
    }

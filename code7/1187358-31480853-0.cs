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
                  "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + 
                    "<activities>" +
                      "<task>" +
                        "<name>Task1</name>" +
                        "<time>00:00</time>" +
                        "<subtask>" +
                          "<name>Task1 - subtask1</name>" +
                          "<time>00:00</time>" +
                        "</subtask>" +
                        "<subtask>" +
                          "<name>Task1 - subtask2</name>" +
                          "<time>00:00</time>" +
                        "</subtask>" +
                      "</task>" +
                      "<task>" +
                        "<name>Task2</name>" +
                        "<time>00:00</time>" +
                        "<subtask>" +
                          "<name>Task2 - subtask1</name>" +
                          "<time>00:00</time>" +
                        "</subtask>" +
                      "</task>" +
                    "</activities>" ;
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("task").Select(x => new {
                    name = x.Element("name").Value,
                    time = x.Element("time").Value,
                    subtask = x.Elements("subtask").Select(y => new {
                        name = y.Element("name"),
                        time = y.Element("time")
                    })
                    .ToList()
                })
                .ToList();
            }
        }
    }
    ​

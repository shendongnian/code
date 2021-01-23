    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication97
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = 
                    "<Root>" +
                    "<Pedestrian Name='Kid'>" +
                        "<Initial_Position In_X='2' In_Y='2' />" +
                        "<Final_Position Fin_X='3' Fin_Y='3' Time='10' />" +
                        "<Final_Position Fin_X='4' Fin_Y='4' Time='12' />" +
                    "</Pedestrian>" +
                    "<Pedestrian Name='Mother'>" +
                        "<Initial_Position In_X='3' In_Y='3' />" +
                        "<Final_Position Fin_X='3' Fin_Y='3' Time='10' />" +
                    "</Pedestrian>" +
                    "</Root>";
                XElement root = XElement.Parse(xml);
                var results = root.Descendants("Pedestrian").Select(x => new
                {
                    name = (string)x.Attribute("Name"),
                    initialPosition = x.Elements("Initial_Position")
                       .Select(y => new { x = (int)y.Attribute("In_X"), y = (int)y.Attribute("In_Y") }).FirstOrDefault(),
                    finalPosition = x.Elements("Final_Position")
                       .Select(y => new { x = (int)y.Attribute("Fin_X"), y = (int)y.Attribute("Fin_Y"), Time = (int)y.Attribute("Time")}).ToList()
                }).ToList();
            }
        }
    }

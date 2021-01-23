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
                XNamespace ns = "abc";
                XElement request = new XElement(ns + "Request", new object[] {
                   new XElement(ns + "Cont"),
                   new XElement(ns + "Lea"),
                   new XElement(ns + "Deal"),
                   new XElement(ns + "Esc"),
                   new XElement(ns + "Esc"),
                   new XElement(ns + "Esc"),
                   new XElement(ns + "Esc"),
                   new XElement(ns + "Esc"),
                   new XElement(ns + "Part"),
                   new XElement(ns + "Veh")
                });
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                Order order = new Order();
                while(reader.ReadToFollowing("Orders"))
                {
                    string xml = reader.ReadOuterXml().Trim();
                    XElement element = XElement.Parse(xml);
                    order.Add(element);
                }
                order.Sort();
                
            }
        }
        public class Order
        {
            public void Add(XElement element)
            {
                if (orders == null)
                {
                    orders = new List<Order>();
                }
                Order newOrder = new Order();
                newOrder.OrderId = int.Parse(element.Element("OrderID").Value);
                newOrder.CustomerId = element.Element("CustomerID").Value;
                newOrder.EmployeeId = int.Parse(element.Element("EmployeeID").Value);
                newOrder.OrderDate = DateTime.Parse(element.Element("OrderDate").Value);
                newOrder.RequiredDate = DateTime.Parse(element.Element("RequiredDate").Value);
                newOrder.ShippedDate = DateTime.Parse(element.Element("ShippedDate").Value);
                newOrder.ShipVia = int.Parse(element.Element("ShipVia").Value);
                newOrder.Freight = double.Parse(element.Element("Freight").Value);
                newOrder.ShipName = element.Element("ShipName").Value;
                newOrder.ShipAddress = element.Element("ShipAddress").Value;
                newOrder.ShipCity = element.Element("ShipCity").Value;
                newOrder.ShipPostalCode = int.Parse(element.Element("ShipPostalCode").Value);
                newOrder.ShipCountry = element.Element("ShipCountry").Value;
                orders.Add(newOrder);
            }
            public void Sort()
            {
                orders = orders.OrderBy(x => x.OrderId).ToList();
            }
            public static List<Order> orders { get; set; }
            public int OrderId { get; set; }
            public string CustomerId { get; set; }
            public int EmployeeId { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime RequiredDate { get; set; }
            public DateTime ShippedDate { get; set; }
            public int ShipVia { get; set; }
            public double Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public int ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }
        }
    }
    ​

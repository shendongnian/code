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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var groups = doc.Descendants("orderItem")
                    .GroupBy(x => (string)x.Element("OrderId"))
                    .Select(x => x.Select(y => new {orderId = y, amount = (int)y.Element("amount")}))
                    .ToList();
                for (int groupNum = groups.Count - 1; groupNum >= 0; groupNum--)
                {
                    var group = groups[groupNum];
                    int total = group.Select(x => x.amount).Sum();
                    for (int orderItemCount = group.Count() - 1; orderItemCount >= 0; orderItemCount--)
                    {
                        var orderItem = group.Skip(orderItemCount).FirstOrDefault();
                        if (orderItemCount > 0)
                        {
                            orderItem.orderId.Remove();
                        }
                        else
                        {
                            XElement amount = orderItem.orderId.Element("amount");
                            amount.Value = total.ToString();
                        }
                    }
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input1 =
                    "<Seq1>" +
                      "<Customer CustomerID=\"g\">G</Customer>" +
                      "<Customer CustomerID=\"p\">P</Customer>" +
                      "<Customer CustomerID=\"r\">R</Customer>" +
                      "<Customer CustomerID=\"s\">S</Customer>" +
                    "</Seq1>";
                XElement element1 = XElement.Parse(input1);
     
                string input2 = 
                    "<Seq2>" +
                      "<Order OrderID=\"11\" CID=\"r\">flash</Order>" +
                      "<Order OrderID=\"12\" CID=\"r\">mouse</Order>" +
                      "<Order OrderID=\"21\" CID=\"s\">phone</Order>" +
                      "<Order OrderID=\"22\" CID=\"s\">pc</Order>" +
                      "<Order OrderID=\"23\" CID=\"s\">camera</Order>" +
                      "<Order OrderID=\"41\" CID=\"p\">card</Order>" +
                    "</Seq2>";
                XElement element2 = XElement.Parse(input2);
                var results =
                    (from cust in element1.DescendantsAndSelf("Seq1").Elements("Customer")
                    join order in element2.DescendantsAndSelf("Seq2").Elements("Order") on cust.Attribute("CustomerID").Value equals order.Attribute("CID").Value into comb
                    from noMatch in comb.DefaultIfEmpty()
                    select new { Customer = cust, Order = noMatch == null ? null : noMatch })
                    .GroupBy(x => x.Customer.Attribute("CustomerID").Value, y => y)
                    .ToList();
                //<GroupJoin>
                //  <Join>
                //    <Customer CustomerID="g">G</Customer>
                //    <Group Count="0" />
                //  </Join>
                //  <Join>
                //    <Customer CustomerID="p">P</Customer>
                //    <Group Count="1">
                //      <Order OrderID="41" CID="p">card</Order>
                //    </Group>
                //  </Join>
                //  <Join>
                //    <Customer CustomerID="r">R</Customer>
                //    <Group Count="2">
                //      <Order OrderID="11" CID="r">flash</Order>
                //      <Order OrderID="12" CID="r">mouse</Order>
                //    </Group>
                //  </Join>
                //  <Join>
                //    <Customer CustomerID="s">S</Customer>
                //    <Group Count="3">
                //      <Order OrderID="21" CID="s">phone</Order>
                //      <Order OrderID="22" CID="s">pc</Order>
                //      <Order OrderID="23" CID="s">camera</Order>
                //    </Group>
                //  </Join>
                //</GroupJoin>
                XElement groupJoin = new XElement("GroupJoin");
                foreach (var result in results)
                {
                    XElement join = new XElement("Join");
                    groupJoin.Add(join);
                    join.Add(result.FirstOrDefault().Customer);
                    XElement group = new XElement("Group");
                    join.Add(group);
                    if (result.FirstOrDefault().Order != null)
                    {
                        var count = result.Count();
                        group.Add(new XAttribute("Count", count));
                        foreach (var order in result)
                        {
                            group.Add(order.Order);
                        }
                    }
                    else
                    {
                        group.Add(new XAttribute("Count",0));
                    }
                }
                
            }
        }
    }
    ​

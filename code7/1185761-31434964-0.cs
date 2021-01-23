    class Program
    {
        static void Main(string[] args)
        {
            XNamespace ns = "https://mws.amazonservices.com/Orders/2013-09-01";
            var xml1 = XDocument.Load("Orderlist.xml");
            var xml2 = XDocument.Load("Orderlist2.xml");
            xml1.Descendants(ns + "ListOrderItemsResult").LastOrDefault().AddAfterSelf(xml2.Descendants(ns + "ListOrderItemsResult"));
            xml1.Save("Orderlist.xml");
        }
    }

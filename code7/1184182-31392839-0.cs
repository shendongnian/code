    using System.Xml;
    class Program
    {
        static void Main(string[] args) 
        {
            XmlDocument list1 = new XmlDocument();
            XmlDocument list2 = new XmlDocument();
            list1.Load("orderlist.xml");
            list2.Load("orderlist2.xml");
            foreach (XmlNode childOfSecond in list2.DocumentElement.ChildNodes)
            {
                XmlNode childOfFirst = list1.ImportNode(childOfSecond, true);
                list1.DocumentElement.AppendChild(childOfFirst);
            }
            list1.Save("orderlist3.xml");
        }
    }

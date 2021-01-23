    using System.Xml.Linq;
    XDocument xdoc = XDocument.Load(@"...\path\document.xml");
    List<xmlvalues> lists = from lv1 in xdoc.Descendants("instance")
                           select new
                           {
                               id = lv1.Element("id"),
                               a= lv1.Element("a"),
                               b= lv1.Element("b"),
                               c= lv1.Element("c")
                           }.Tolist();

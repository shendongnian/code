    using System.Xml.Linq;
    XDocument xdoc = XDocument.Load(@"...\path\document.xml");
    List<xmlvalues> lists = from lv1 in xdoc.Descendants("instance")
                           select new
                           {
                               id = lv1.Attribute("id ").Value,
                               a= lv1.Attribute("a").Value,
                               b= lv1.Attribute("b").Value,
                               c= lv1.Attribute("c").Value
                           }.Tolist();

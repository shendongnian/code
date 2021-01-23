    // example data:
    XDocument xmldoc = XDocument.Parse(
    @"
    <a>
    <b></b>
    <e>
       <b></b>
       <c></c>
    </e>
    <c />
    <e>
       <b></b>
       <c></c>
       <c></c>
    </e>
    </a>
    ");
                // you can use xpath, then you need to add:
                // using System.Xml.XPath;
                List<XElement> elementsToReplace = xmldoc.XPathSelectElements("a/e").ToList();
    
                // or pure linq-to-sql:
                // elementsToReplace = xmldoc.Elements("a").Elements("e").ToList();
    
                foreach (XElement elem in elementsToReplace)
                {
                    // setting Value of XElement to an empty string causes the resulting xml to look like this:
                    // <elem></elem>
                    // and not like this:
                    // <elem />
                    elem.ReplaceWith(new XElement("elem", ""));
                    // if you don't mind self closing tags, then:
                    // elem.ReplaceWith(new XElement("elem"));
                }

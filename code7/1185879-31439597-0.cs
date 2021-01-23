    private static string GetCompanyValue(IEnumerable<XElement> books, string side, string r)
    {
       string format = "Title[@Side={0}]/Pty[@R={1}]";
       return GetValueByXPath(books, string.Format(format, side, r));
    }
    
    private static string GetBrokerValue(IEnumerable<XElement> books, string side)
    {
        string format = "Title[@Side={0}]/Pty[@R=1]/Sub[@Typ=26]";
        return GetValueByXPath(books, string.Format(format, side));
    }
    
    private static string GetValueByXPath(IEnumerable<XElement> books, string expression)
    {
        XElement element = null;
    
        foreach (XElement book in books)
        {
            element = book.XPathSelectElement(expression);
    
            if (element != null)
            {
               break;
            }
         }
    
         return element != null ? element.Attribute("ID").Value : null;
     }

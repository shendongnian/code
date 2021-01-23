    public static class MyXDocumentExtensions
    {
        public static bool CityExists(this XDocument doc, string cityName)
        {
            //Contains
            //var matchingElements = doc.XPathSelectElements(string.Format("//city[contains(text(), '{0}')]", cityName));
            //Equals
            var matchingElements = doc.XPathSelectElements(string.Format("//city[text() = '{0}']", cityName));
            
            return matchingElements.Count() > 0;
        }
    }

    string category = dm.Element("category").GetValueOrDefault("Uncategorized");
    string url = dm.Element("url").GetValueOrDefault();
    //...
    
    public static class XElementExtension { 
        // GetValueOrDefault extension for XElement
        public static string GetValueOrDefault(this XElement element, string defaultValue = null) {
            return (element != null) ? element.Value : defaultValue;
        }
    }

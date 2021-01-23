    using System.Xml.Linq;
    // Create a list just in case you want to remove specific elements later
    List<XElement> toRemove = new List<XElement>();
    // Load the config file
    XDocument doc = XDocument.Load("app.config");
    // Get the appSettings element as a parent
    XContainer appSettings = doc.Element("configuration").Element("appSettings");
    // step through the "add" elements
    foreach (XElement xe in appSettings.Elements("add"))
    {
        // Get the values
        string addKey = xe.Attribute("key").Value;
        string addValue = xe.Attribute("value").Value;
        // if you want to remove it...
        if (addValue == "something")
        {
            // you can't remove it directly in the foreach loop since it breaks the enumerable
            // add it to a list and do it later
            toRemove.Add(xe);
        }
    }
    // Remove the elements you've selected
    foreach (XElement xe in toRemove)
    {
        xe.Remove();
    }
    // Add any new Elements that you want
    appSettings.Add(new XElement("add", 
        new XAttribute("key", "\\inculde"),
        new XAttribute("value", "chapX")));

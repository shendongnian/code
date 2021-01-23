    XElement root = XElement.Load(file);
    // Get all the orders
    var orders = root.Descendants("Order").ToList();
    // Remove the orders from the XML file
    orders.Remove();
    // Sort the orders
    var sortedOrders = orders.OrderBy(o => (DateTime)o.Element("OrderDate"));
    // Re-Add them to the XML file
    root.Element("Orders").Add(sortedOrders);
    root.Save(file);

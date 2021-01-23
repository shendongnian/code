    var doc = XDocument.Parse(xml);
    
    var orderId = (string)doc.Descendants("Items")
        .Select(e => e.Attribute("orderId"))
        .Single();
    var orderDate = (string)doc.Descendants("orderDate").Single();
    var buyerId = (string)doc.Descendants("buyerId").Single();
    
    Console.WriteLine("Order ID: {0}", orderId);
    Console.WriteLine("Order Date: {0}", orderDate);
    Console.WriteLine("Buyer ID: {0}", buyerId);
    
    foreach (var item in doc.Descendants("item"))
    {
        var id = (string)item.Attribute("itemId");
        var name = (string)item.Element("itemName");
        var description = (string)item.Element("desc");
        var quantity = (int)item.Element("quantity");
        var price = (decimal)item.Element("unitPrice");
    
        Console.WriteLine("---");
        Console.WriteLine("Item ID: {0}", id);
        Console.WriteLine("Item Name: {0}", name);
        Console.WriteLine("Item Description: {0}", description);
        Console.WriteLine("Item Quantity: {0}", quantity);
        Console.WriteLine("Item Price: {0}", price);
    }

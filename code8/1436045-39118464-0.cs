    XDocument doc = XDocument.Load(@"E:\test\r.xml");
    
    var data =
       doc.Descendants("stock").Elements("dealer")
          .Select(
                  a =>
                      new
                         {
                           DealerName = a.Element("dealername").Value,
                           VehiclesCount = a.Descendants("vehicle").Count()
                         });
    
    foreach (var d in data)
    {
        Console.WriteLine(d.DealerName);
        Console.WriteLine(d.VehiclesCount);
    }

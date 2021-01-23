    var root = XElement.Load(myPath);
    List<XElement> deleteMe = new List<XElement>();
    foreach (var item in root.Elements())
    {
        if (item.Element("body").Element("cf").Value.Equals(myCf))
        {
            deleteMe.Add(item);
        }
    }
    Console.WriteLine("Deleting: " + String.Join(",",deleteMe.Select(x => x.Element("head").Element("nr").Value)));
    Console.ReadKey();
    foreach (var item in deleteMe)
    {
        item.Remove();
    }
    root.Save(myPath2);

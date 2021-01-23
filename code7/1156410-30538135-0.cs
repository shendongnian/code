    var index     = 0;
    var output    = new XmlDocument();
    var order     = output.AppendChild(output.CreateElement("Order"    ));
    var subjects  = order .AppendChild(output.CreateElement("Subjects" ));
    var addresses = order .AppendChild(output.CreateElement("Addresses"));
    foreach (XmlElement subject in input.SelectNodes("/Subjects/Subject"))
    {
        index++;
        var address = (XmlElement)subject.RemoveChild(subject.SelectSingleNode("Addresses"));
            address = (XmlElement)address.FirstChild;   // Addresses to Address
            address.SetAttribute("id", index.ToString());
                    
        var newAddress = (XmlElement)subject.AppendChild(input.CreateElement("Address"));
            newAddress.SetAttribute("ref", index.ToString());
        subjects .AppendChild(output.ImportNode(subject, true));
        addresses.AppendChild(output.ImportNode(address, true));
    }
    output.Save(Console.Out);
    Console.ReadLine();

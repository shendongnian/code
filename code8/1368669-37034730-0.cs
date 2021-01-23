    XDocument Xdoc;
    
    if (System.IO.File.Exists(filepath))
    {
        Xdoc = XDocument.Load(filepath);
    }
    else
    {
        Xdoc = new XDocument(new XElement("Members"));
    }
    
    XElement member = Xdoc
        .Descendants("Member")
        .FirstOrDefault(m => (string) m.Element("Name") == name);
    
    if (member != null)
    {
        member.Element("Age").Value = age;
        member.Element("Nationality").Value = age;
        member.Element("EmailAddress").Value = age;
        member.Element("ContactNumber").Value = age;
    }
    else
    {
        XElement newMember = new XElement("Member",
            new XElement("Name", name),
            new XElement("Age", age),
            new XElement("Nationality", nationality),
            new XElement("EmailAddress", email),
            new XElement("ContactNumber", contactNumber)
            );
    
        Xdoc.Descendants("Members").First().Add(newMember);
    }
    
    Xdoc.Save(filepath);

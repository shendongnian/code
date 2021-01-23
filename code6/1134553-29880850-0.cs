    private static XDocument GroupContactsByGroupField(XDocument doc)
        {
            var contacts = doc.Descendants("Contact").Select(x => new
            {
                FirstName = x.Element("First_Name").Value,
                LastName = x.Element("Last_Name").Value,
                Group = x.Element("Group").Value,
                HomeNumber = x.Element("Home_Number").Value,
                MobileNumber = x.Element("Mobile_Number").Value
            });
            var contactsGroupedByGroup = contacts.GroupBy(x => x.Group);
            
            var newDoc = new XDocument(new XElement("Groups", contactsGroupedByGroup.Select(x =>
               new XElement("Group", new XAttribute("Name", x.Key),
                x.Select(y => new XElement("Contact",
                    new XElement("First_Name", y.FirstName),
                    new XElement("Last_Name", y.LastName),
                    new XElement("Home_Number", y.HomeNumber),
                    new XElement("Mobile_Number", y.MobileNumber)
                ))))));
            return newDoc;
        }
    

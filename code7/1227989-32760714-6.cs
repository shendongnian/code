    XElement xml = new XElement("Sections",
                                    from col in lstSections
                                    select new XElement("rows",
                                                   new XElement("UserId", col.UserId),
                                                   new XElement("SectionId", col.SectionId),
                                                   new XElement("IsActive", col.IsActive)));
    
                                  string  xmlString = xml.ToString();

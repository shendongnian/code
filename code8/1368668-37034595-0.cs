    XDocument Xdoc = new XDocument(new XElement("XMLFile"));
    if (System.IO.File.Exists(filepath))
    {
         Xdoc = XDocument.Load(filepath);
    }
    else
    {
         Xdoc = new XDocument();
    }
    var existing = Xdoc.Descendants("Member").FirstOrDefault(m => m.Element("Name")?.Value == txtName.Text);
    if (existing != null) //name existed in xml
    {
          existing.Element("Age").Value = txtAge.Text;
          //....
          //....
    }
    else
    {
          XElement xml = new XElement("Member");
          xml.Add(new XElement("Name", txtName.Text));
          xml.Add(new XElement("Age", txtAge.Text));
          xml.Add(new XElement("Nationality", txtNationality.Text));
          xml.Add(new XElement("EmailAddress", txtEmailAddress.Text));
          xml.Add(new XElement("ContactNumber", txtContactNumber.Text));
          if (Xdoc.Descendants().Count() > 0)
          {
              Xdoc.Descendants().First().Add(xml);
          }
          else
          {
              Xdoc.Add(xml);
          }
    }
    Xdoc.Save(filepath));

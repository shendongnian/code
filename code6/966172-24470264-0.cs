    for (int i = 0; i < expressions.Count; i++)
    {
                ViewPresentation VP = new ViewPresentation(); // this is the new line. Will create a new object for every iteration
                var xml = XElement.Parse(expressions[i].ToString());
                VP.columName = xml.Attribute("Name").Value;
                VP.displayName = xml.Attribute("DisplayName").Value;
                VP.memberBinding = xml.Attribute("DisplayMemberBinding").Value;
                VP.property = xml.Attribute("Property").Value;
                VP.dataType = xml.Attribute("DataType").Value;
                VP.viewwidth = xml.Attribute("Width").Value;
                listColumns.Add(VP);
    }

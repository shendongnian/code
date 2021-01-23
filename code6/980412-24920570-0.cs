    var xmlList = (from message in xmlElement.Elements("DATA")
                    select new
                    {
                        internalid = message.Attribute("internalid").Value,
                        externalid = message.Attribute("externalid").Value,
                        lastname = message.Attribute("lastname").Value,
                        firstname = message.Attribute("firstname").Value,
                        date = message.Attribute("date").Value
                    });
    StringBuilder builder = new StringBuilder();
    foreach (var item in xmlList)
    {
        builder.Append(item);
    }
    string test = builder.ToString();

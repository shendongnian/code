    var query1 = from item in xDoc.Descendants("ORDER")   // xDoc.Elements() //xDoc.Descendants("ORDER") // xDoc.Root.Elements("ORDER")
    select new
    {
        EmpNum = item.Element("EMPNUMBER").Value,
        ItemName = item.Element("ITEMNAME").Value,
        OrderDate = Convert.ToDateTime(item.Element("DATETIMESTAMP").Value),
        Accts = item.Element("SHIPMENTLIST").Elements("ACCT").Select(x => x.Value).ToList()
    };

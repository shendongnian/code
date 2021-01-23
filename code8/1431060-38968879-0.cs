    DataTable YourTable = new DataTable();
                YourTable.Columns.Add("Name", typeof(string));
                YourTable.Columns.Add("Type", typeof(string));
                YourTable.Columns.Add("VALUE", typeof(string));
    string XMLResult =string.Empty;
    using (StringWriter sw = new StringWriter())
     {
        YourTable.TableName = "XMLPRODUCTDETAILS";
        YourTable .WriteXml(sw);
        XMLResult = sw.ToString();
     }

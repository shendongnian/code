    DataTable fileDetailsTable = new DataTable();
    fileDetailsTable.Columns.Add("Key", typeof(string));
    fileDetailsTable.Columns.Add("Value", typeof(string));
    
    HtmlNodeCollection enumNodes = document.DocumentNode.SelectNodes("//div[@id='file-details']//div[@class='enum-container']//div[@class='enum']");
    foreach (HtmlNode enumNode in enumNodes)
    {
        //Select the child span from the enum node.
        HtmlNode fieldKeyNode = enumNode.SelectSingleNode("span[@class='field-key']");
    
        if (fieldKeyNode != null)
        {
            //Grab the key.
            string fieldKey = fieldKeyNode.InnerText;
    
            //Grab the value which is the field key's sibling
            string fieldValue = fieldKeyNode.NextSibling.InnerText;
    
            fileDetailsTable.Rows.Add(fieldKey, fieldValue);
        }
    }

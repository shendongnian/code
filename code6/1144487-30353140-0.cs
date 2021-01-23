    var trTags4Header = document.DocumentNode.SelectNodes("//tr[@class='tableheader']");
    if (trTags4Header != null)
    {
        //Create a list to store td values 
        List<string> tableList1 = new List<string>();
        int row = 2;
        foreach (var item in trTags4Header)
        {
            //Get only next siblings which matches the calss name as "content" 
            var found = item.SelectNodes("followin-sibling::*").TakeWhile(tag => tag.Name == "tr" && tag.Attributes["class"].Value == "content");
            //store the nodes selected in an array (this is the selection of nodes I wanted which has td information I want. 
            HtmlNode[] nextItem = found.ToArray();
            foreach (var node in nextItem)
            {
                //Gets individual td values within tr class='content' Notice .//td- this starts looking from the present node instead of the root nodes.
                var tdValues = node.SelectNodes(".//td").TakeWhile(tdTag => tdTag.Name == "td");
                int column = 1;
                //Stores each td values into the list which is why I have control over the data to where I want to store, I am storing them in one excel worksheet.
                foreach (var tdText in tdValues)
                {
                    tableList1.Add(tdText.InnerText);
                    ws1.Cells[row, column] = tdText.InnerText;
                    column++;
                }
                row++;
             }
         }
         //Display the content in a listbox 
         listBox1.DataSource = tableList1;
    }

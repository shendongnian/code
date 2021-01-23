    public DataTable tableIntoTable(HtmlDocument doc)
            {
                var table = new DataTable("MyTable");
                table.Columns.Add("raw", typeof(string));
                var xpath = @"//th[@class='ddlabel'] | //table[not(.//*[contains(@*,'pldefault') or contains(@*,'ntdefault') or contains(@*,'bgtabon')])]";
                var nodes = doc.DocumentNode.SelectNodes(xpath);
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        table.Rows.Add(node.InnerHtml);
                    }
                }
    
                return table;
            }

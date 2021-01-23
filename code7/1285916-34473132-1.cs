            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            // Load a file
            html.Load(@"c:\OneDrive\Work\MS Projects\text.html");       
            HtmlNode table = html.DocumentNode.SelectSingleNode("//table[@border='1']");
            DataTable dt = new DataTable();
            var rows = table.SelectNodes("tr");
            for (int i = 0; i < rows.Count; ++i)
            {
                //if row = then these are headers
                if (i == 0)
                {
                    var cols = rows[i].SelectNodes("th");                    
                    dt.Columns.Add(new DataColumn(cols[0].InnerText.ToString()));
                    dt.Columns.Add(new DataColumn(cols[1].InnerText.ToString()));                    
                    dt.Columns.Add(new DataColumn(cols[3].InnerText.ToString()));
                    dt.Columns.Add(new DataColumn(cols[2].InnerText.ToString()));
                    dt.Columns.Add(new DataColumn(cols[4].InnerText.ToString()));
                }
                //row>0 then data
                else
                {
                    var cols = rows[i].SelectNodes("td");
                    DataRow dr = dt.NewRow();
                    dr[0] = cols[0].InnerText.ToString();
                    dr[1] = cols[1].InnerText.ToString();
                    dr[2] = cols[3].InnerText.ToString();
                    dr[3] = cols[2].InnerText.ToString();
                    dr[4] = cols[4].InnerText.ToString();
                    dt.Rows.Add(dr);
                }
            }

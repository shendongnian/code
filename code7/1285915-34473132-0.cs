            String tablePrep = webHTML.Split(new string[] { "<table border=\"1\" bordercolor=\"#808080\" cellpadding=\"2\">"}, StringSplitOptions.None)[1];
            String table = tablePrep.Split(new string[] { "</table>" }, StringSplitOptions.None)[0];
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(table);
            var rows = doc.DocumentNode.SelectNodes("//tr");
            for (int i = 1; i < rows.Count; ++i)
            {
                var cols = rows[i].SelectNodes("td");
                String col0Val = cols[0].InnerText.ToString();
                String col1Val = cols[1].InnerText.ToString();
                String col2Val = cols[2].InnerText.ToString();
                String col3Val = cols[3].InnerText.ToString();
                String col4Val = cols[4].InnerText.ToString();                
            }

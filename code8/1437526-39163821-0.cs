        foreach (DataRow row in dt.Rows)
        {
            htmlRender.Append("<ul>");
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                var courseCategory = row[i-1];
                htmlRender.Append("<li data-id='"+ courseCategory + "'>");
                htmlRender.Append(row[i]);
                htmlRender.Append("</li>");                    
            }
            htmlRender.Append("</ul>");                
        }

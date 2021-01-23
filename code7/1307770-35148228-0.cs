       foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    if(column.ColumnName=='id')
                    {
                        html.Append("<button type = \"button\" > Edit!</button>");
                    }else{
                          html.Append(row[column.ColumnName]);  
                    }                    
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

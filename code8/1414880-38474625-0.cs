        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        // set the contentencoding of the http content
        Response.ContentEncoding = Encoding.UTF8;
        // use a streamwriter that knows how to write strings in 
        // a specified encoding to a stream
        using(var sw = new StreamWriter(Response.OutputStream, Response.ContentEncoding))
        {
            string tab = "";
            foreach (DataColumn dc in dt3.Columns)
            {
                // use the StreamWriter
                sw.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            sw.Write("\n");
            int i;
            foreach (DataRow dr in dt3.Rows)
            {
                tab = "";
                for (i = 0; i < dt3.Columns.Count; i++)
                {
                    sw.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                sw.Write("\n");
            }
        }
        Response.End();

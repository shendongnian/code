        public void DataTableToExcel(DataTable dt)
        {
            string attachment = "attachment; filename=download.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
        Response.ContentEncoding = System.Text.Encoding.UTF32;
        Response.BinaryWrite(System.Text.Encoding.UTF32.GetPreamble());
            Response.ContentType = "application/vnd.xls";
            string tab = "";
            foreach (DataColumn dc in dt.Columns) // table col
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            string content = "";
            foreach (DataRow dr in dt.Rows) // Data Row by row
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    content = dr[i].ToString();
                    content = content.Replace(System.Environment.NewLine, " ");
                    Response.Write(tab + content);
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

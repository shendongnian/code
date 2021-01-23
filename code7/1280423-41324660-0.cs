    public class ExcelExporter 
    {
        DataTable dt;
        string filename = "Output.xlsx";
        // create exporter for datatable
        public ExcelExporter(DataTable dt)
        {
            this.dt = dt;
        }
    
        // creates an exporter for a datatable and filename
        public ExcelExporter(DataTable dt, string filename):this(dt)
        {
            this.filename = filename;
        }
    
        // exports excel to given httpResponse
        public void Export(HttpResponse response)
        {
            Response.Clear();
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader(
                "content-disposition", 
                String.Format("attachment;filename={0}",filename));
    
            Response.BinaryWrite(Export());
    
            Response.Flush();
            Response.End();
    
        }
    
        // export excel package in path with defaukt name
        public void Export(string path)
        {
            Export(path, filename);
        }
    
        // export excel package as file in path
        public void Export(string path, string file)
        {
            var full = Path.Combine(path, file);
            File.WriteAllBytes(full, Export());
        }
    
        //exort Excel package as Byte array
        public byte[] Export()
        {
            ExcelPackage pck = new ExcelPackage();
            using (pck)
            {
                ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
                wsDt.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.None);
    
                int colNumber = 1;
    
                foreach (DataColumn col in dt.Columns)
                {
    
                    if (col.DataType == typeof(DateTime))
                    {
                        wsDt.Column(colNumber).Style.Numberformat.Format = "yyyy-mm-dd";
                    }
                    colNumber = colNumber + 1;
                }
    
                wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();
                return pck.GetAsByteArray();   
            }
        }
    
    }

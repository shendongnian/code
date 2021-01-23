        public FileStreamResult ExcelReport(int type)
        {
            var body = _db.MyObjects.Where(x => x.Type == type);
            ReportDataSource rdsBody = new ReportDataSource("MyReport", body);
            ReportViewer viewer = new ReportViewer 
            { 
                ProcessingMode = ProcessingMode.Local 
            };
            viewer.LocalReport.ReportPath = Server.MapPath(@"~\bin\MyReport.rdlc");
            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(rdsBody);
            viewer.LocalReport.EnableHyperlinks = true;
            string filename = string.Format("MyReport_{0}.xls", type); 
            byte[] bytes = viewer.LocalReport.Render("Excel");
            var stream = new MemoryStream(bytes);
            return File(stream, "application/ms-excel", filename);
        }

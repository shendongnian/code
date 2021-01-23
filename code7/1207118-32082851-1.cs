        [HttpPost]
        public ActionResult DisplayPdfInIframe(string test)
        {
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath(@"~/Reports/Report.rpt");
            rptH.SetParameterValue("@ID", 33);
            rptH.Load();
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return new FileStreamResult(stream, "application/pdf");
        } 

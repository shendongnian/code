    public class DownloadCsvActionResult : ActionResult
    {
        public ReportBase Report { get; set; }
        public string fileName { get; set; }
        private string ReportData { get; set; }
        public DownloadCsvActionResult(ReportBase report, string pFileName)
        {
            Report = report;
            fileName = pFileName;
            ReportData = RenderReport();
        }
        private string RenderReport()
        {
            var reportBody = new StringBuilder();
            reportBody.AppendLine(Report.ReportName);
            reportBody.Append(Environment.NewLine + Environment.NewLine);
            foreach (var thisSection in Report.ReportSections)
            {
                reportBody.Append(thisSection.ReportSectionName + Environment.NewLine);
                if (thisSection.ReportItems != null)
                {
                    var itemType = thisSection.ReportItems.GetType().GetGenericArguments().Single();
                    var first = true;
                    foreach (var prop in itemType.GetProperties())
                    {
                        if (!first) reportBody.Append(",");
                        DisplayAttribute attribute = prop.GetCustomAttributes(typeof(DisplayAttribute), false)
                             .Cast<DisplayAttribute>()
                             .SingleOrDefault();
                        string displayName = (attribute != null) ? attribute.Name : prop.Name;
                        reportBody.Append(displayName);
                        first = false;
                    }
                    reportBody.Append(Environment.NewLine);
                    foreach (var thisItem in thisSection.ReportItems)
                    {
                        var firstData = true;
                        foreach (var prop in itemType.GetProperties())
                        {
                            if (!firstData) reportBody.Append(",");
                            reportBody.Append(prop.GetValue(thisItem,null));
                            firstData = false;
                        }
                        reportBody.Append(Environment.NewLine);
                    }
                }
                reportBody.Append(Environment.NewLine);
            }
            return reportBody.ToString();
        }
        public override void ExecuteResult(ControllerContext context)
        {
            //Create a response stream to create and write the Excel file
            HttpContext curContext = HttpContext.Current;
            curContext.Response.Clear();
            curContext.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            curContext.Response.Charset = "";
            curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            curContext.Response.ContentType = "application/vnd.ms-excel";
            //Write the stream back to the response
            curContext.Response.Write(ReportData);
            curContext.Response.End();
        }
    }

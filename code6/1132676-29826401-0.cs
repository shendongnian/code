           using (var lr = new LocalReport())
            {
                
                var path = Path.Combine(HttpRuntime.AppDomainAppPath, "Report", "MyInvoice.rdlc");
                lr.ReportPath = path;
                var siteName = ConfigurationManager.AppSettings["siteName"];
                var companyName = ConfigurationManager.AppSettings["companyName"];
                var @params = new ReportParameter[2];
                @params[0] = new ReportParameter("siteName", siteName);
                @params[1] = new ReportParameter("companyName",companyName);
                var usersinv = db.Invoices.Where(i => i.Id == invoiceid.Id);
                var invoice = usersinv.SingleOrDefault();
                if (invoice != null)
                {
                    var invoiceitems = db.InvoiceItems.Where(i => i.InvoiceId == invoiceid.Id);
                    var rd1 = new ReportDataSource("Invoice", usersinv);
                    var rd2 = new ReportDataSource("InvoiceItems", invoiceitems.ToList());
                    
                    lr.DataSources.Add(rd1);
                    lr.DataSources.Add(rd2);
                    lr.SetParameters(@params);
                }
                string encoding;
                string fileNameExtention;
                const string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>PDF</OutputFormat>" +
                "  <PageWidth>21cm</PageWidth>" +
                "  <PageHeight>29.7cm</PageHeight>" +
                "  <MarginTop>0.0cm</MarginTop>" +
                "  <MarginLeft>0.0cm</MarginLeft>" +
                "  <MarginRight>0.0cm</MarginRight>" +
                "  <MarginBottom>0.0cm</MarginBottom>" +
                "</DeviceInfo>";
                Microsoft.Reporting.WebForms.Warning[] warnings;
                string[] streams;
                renderedBytes = lr.Render("PDF",
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtention,
                    out streams,
                    out warnings);
            }
            return File(renderedBytes, mimeType);

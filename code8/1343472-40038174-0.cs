    public HttpResponse GetRequistionPdf(modelClass oModel)  
        {       
            HttpResponse response = HttpContext.Current.Response;
            ReportController _Report = new ReportController();
    
                    response.Clear()
                    response.ClearContent()
                    response.ClearHeaders()
                    response.Buffer = True
                    response.ContentType = "application/pdf"
                    response.AddHeader("Content-Disposition", "attachment;filename=xyz.pdf")
                    response.BinaryWrite(_Report.GetPdfBytesFormView(oModel));
                    response.End()
    
                 
            return response;
        }

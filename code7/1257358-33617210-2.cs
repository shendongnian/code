	PrintManager prntManager = new PrintManager();
	var data = prntManager.ObjectToPdf(item, para);
	byte[] pdf = null;
	var cfg = new Action<iTextSharp.text.pdf.PdfWriter,iTextSharp.text.Document>((writer, document) =>
	{
		writer.PageEvent = new StandardPrintHelper();
		document.NewPage();
	});
	pdf = ControllerContext.GeneratePdf(prntManager.CreateController<PrintingController>(), data, prntManager.ReportToView(para.Export.Report.Code), cfg);   
	
	HttpContext.Current.Response.AppendHeader("Export-Location",
		prntManager.GeneratePdf(pdf));

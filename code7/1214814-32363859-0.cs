	public byte[] exportPDF(string fileName, string Orientation, string html)
	{
		// etc.
		var pdfBytes = pdf.GeneratePdf(createPDFScript() + html + "</body></html>");
		return pdfBytes;
	}

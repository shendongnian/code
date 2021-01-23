    using Syncfusion.XlsIO;
    using Syncfusion.Pdf;
    using Syncfusion.ExcelToPdfConverter;
    ...
    // in a method
    using (Stream readFile = stream for excel file)
    {
        ExcelToPdfConverter converter = new ExcelToPdfConverter(readFile);
        PdfDocument pdfDoc = new PdfDocument();
        // set Your setting You like
        ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
        settings.TemplateDocument = pdfDoc;
        settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;
        pdfDoc = converter.Convert(settings);
        pdfDoc.Save("ExceltoPDF.pdf", Response, HttpReadType.Save);
        readFile.Close();
    }

    byte[] bOutput;
    Telerik.Windows.Documents.Flow.FormatProviders.Rtf.RtfFormatProvider RTFprovider = new Telerik.Windows.Documents.Flow.FormatProviders.Rtf.RtfFormatProvider();
    string strRTF = System.Text.Encoding.ASCII.GetString(bInput);
    Telerik.Windows.Documents.Flow.Model.RadFlowDocument document = RTFprovider.Import(strRTF);
            Telerik.Windows.Documents.Flow.FormatProviders.Pdf.PdfFormatProvider PDFprovider = new Telerik.Windows.Documents.Flow.FormatProviders.Pdf.PdfFormatProvider();
            bOutput = PDFprovider.Export(document);

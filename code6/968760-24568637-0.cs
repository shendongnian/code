    private static void GeneratePdfFromStream()
        {
            var ms = xml_and_xsl_to_html();
            File.WriteAllBytes(Constants.FilesResultHtml, ms.ToArray());
            var printer = new Printer();
            var pdfStream = printer.GeneratePdf(new StreamReader(ms, Encoding.GetEncoding(850), false));
            File.WriteAllBytes(Constants.FilesResultPdf, pdfStream.ToArray());
        }

    var pdf = new PdfModel2 { SomeProperty = "SomeValue" };
    var pdfType = pdf.GetType();
    pdfType.GetProperties().Where(
        p =>
            p.GetCustomAttribute<PdfTextFieldAttribute>() != null).Select(
        p =>
            p.GetValue(pdf)).Dump();

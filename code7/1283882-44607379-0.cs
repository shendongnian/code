    var dict = new PdfDictionary(document);
    dict.Elements["/Type"] = new PdfName("/Action");
    dict.Elements["/S"] = new PdfName("/Named");
    dict.Elements["/N"] = new PdfName("/Print");
    document.Internals.AddObject(dict);
    document.Internals.Catalog.Elements["/OpenAction"] = PdfSharp.Pdf.Advanced.PdfInternals.GetReference(dict);

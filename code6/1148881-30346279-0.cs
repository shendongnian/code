    public static void ExtractSignatureTextFromFile(FileInfo file)
    {
        try
        {
            Console.Out.Write("File: {0}\n", file);
            using (var pdfReader = new PdfReader(file.FullName))
            {
                AcroFields fields = pdfReader.AcroFields;
                foreach (string name in fields.GetSignatureNames())
                {
                    Console.Out.Write("  Signature: {0}\n", name);
                    iTextSharp.text.pdf.AcroFields.Item item = fields.GetFieldItem(name);
                    PdfDictionary widget = item.GetWidget(0);
                    PdfDictionary ap = widget.GetAsDict(PdfName.AP);
                    if (ap == null)
                        continue;
                    PdfStream normal = ap.GetAsStream(PdfName.N);
                    if (normal == null)
                        continue;
                    Console.Out.Write("    Content of normal appearance: {0}\n", extractText(normal));
                    PdfDictionary resources = normal.GetAsDict(PdfName.RESOURCES);
                    if (resources == null)
                        continue;
                    PdfDictionary xobject = resources.GetAsDict(PdfName.XOBJECT);
                    if (xobject == null)
                        continue;
                    PdfStream frm = xobject.GetAsStream(PdfName.FRM);
                    if (frm == null)
                        continue;
                    PdfDictionary res = frm.GetAsDict(PdfName.RESOURCES);
                    if (res == null)
                        continue;
                    PdfDictionary xobj = res.GetAsDict(PdfName.XOBJECT);
                    if (xobj == null)
                        continue;
                    PRStream n2 = (PRStream) xobj.GetAsStream(PdfName.N2);
                    if (n2 == null)
                        continue;
                    Console.Out.Write("    Content of normal appearance, layer 2: {0}\n", extractText(n2));
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.Write("Error... " + ex.StackTrace);
        }
    }
    public static String extractText(PdfStream xObject)
    {
        PdfDictionary resources = xObject.GetAsDict(PdfName.RESOURCES);
        ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        PdfContentStreamProcessor processor = new PdfContentStreamProcessor(strategy);
        processor.ProcessContent(ContentByteUtils.GetContentBytesFromContentObject(xObject), resources);
        return strategy.GetResultantText();
    }

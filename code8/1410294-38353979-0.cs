    public static byte[] concatAndAddContent(List<byte[]> pdfByteContent) {
        using (var ms = new MemoryStream()) {
            using (var doc = new Document()) {
                using (var copy = new PdfSmartCopy(doc, ms)) {
                    doc.Open();
                    //Loop through each byte array
                    foreach (var p in pdfByteContent) {
                        //Create a PdfReader bound to that byte array
                        using (var reader = new PdfReader(p)) {
                            //Add the entire document instead of page-by-page
                            copy.AddDocument(reader);
                        }
                    }
                    doc.Close();
                }
            }
            //Return just before disposing
            return ms.ToArray();
        }
    }

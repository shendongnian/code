    /// <summary>
    /// Create a fake SSRS report
    /// </summary>
    /// <returns>A valid PDF stored as a byte array</returns>
    private Byte[] getSSRSPdfAsByteArray() {
        using (var ms = new System.IO.MemoryStream()) {
            using (var doc = new Document()) {
                using (var writer = PdfWriter.GetInstance(doc, ms)) {
                    doc.Open();
                    doc.Add(new Paragraph("This is my SSRS report"));
                    doc.Close();
                }
            }
            return ms.ToArray();
        }
    }

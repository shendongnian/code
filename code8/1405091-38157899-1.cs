    public FileResult ConvertPathInfoToPDF(PositionInfo[] pInfo)
        {
            MemoryStream fs = new MemoryStream();
            Rectangle rec = new Rectangle(PageSize.A4);
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hamed!"));
            doc.Close();
            byte[] content = fs.ToArray(); // Convert to byte[]
            return File(content, "application/pdf", "Test.pdf");
        }

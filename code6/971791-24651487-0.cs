     SaveFileDialog svg = new SaveFileDialog();
            svg.ShowDialog();
    
     using (FileStream stream = new FileStream( svg.FileName+ ".pdf", FileMode.Create))
        {
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();
            stream.Close();
        }

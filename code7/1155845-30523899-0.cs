    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(source);
    using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        using (Document doc = new Document(image))
        {
            using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
            {
                doc.Open();
                image.SetAbsolutePosition(0, 0);
                writer.DirectContent.AddImage(image); 
                doc.Close();
             }
         }
    }

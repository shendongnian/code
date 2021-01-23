     iTextSharp.text.Font blackFont = FontFactory.GetFont("Seoge UI", 10, iTextSharp.text.Font.NORMAL, new BaseColor(Color.FromArgb(97, 102, 116)));
        //Path to where you want the file to output
        string outputFilePath = "MergedOutputt.pdf";
        //Path to where the pdf you want to modify is
        //string inputFilePath = "D:\\MergedOutput.pdf";
        try
        {
            using (Stream outputPdfStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (Stream outputPdfStream2 = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                //Opens the unmodified PDF for reading
                var reader = new PdfReader(MergedOutputStream.ToArray());
                //Creates a stamper to put an image on the original pdf
                var stamper = new PdfStamper(reader, outputPdfStream) { FormFlattening = true, FreeTextFlattening = true };
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    //Creates an image that is the size i need to hide the text i'm interested in removing
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(new Bitmap(120, 20), BaseColor.WHITE);
                    //Sets the position that the image needs to be placed (ie the location of the text to be removed)
                    image.SetAbsolutePosition(reader.GetPageSize(i).Width - 120, 42);
                    //Adds the image to the output pdf
                    stamper.GetOverContent(i).AddImage(image, true);
                    //Creates the first copy of the outputted pdf
                    PdfPTable table = new PdfPTable(1);
                    float[] width = new float[] { 38 };
                    table.SetTotalWidth(width);
                    PdfContentByte pb;
                    //Get PdfContentByte object for first page of pdf file
                    pb = stamper.GetOverContent(i);
                    cellSequenceNumber = new PdfPCell(new Phrase(new Chunk("Side " + i.ToString(), blackFont)));
                    cellSequenceNumber.Border = 0;
                    table.AddCell(cellSequenceNumber);
                    table.WriteSelectedRows(0, table.Rows.Count, reader.GetPageSize(i).Width - 82, 54, pb);
                }
                stamper.Close();
                //Opens our outputted file for reading
               var reader2 = new PdfReader(outputPdfStream2);
               reader2.Close();               
               
              
              
            }
        }

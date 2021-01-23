    //Instead of writing to a file, we're going to just keep a byte array around
    //that we can work with and/or write to something else
    //At the start, this array is not initialized to anything
    Byte[] bytes;
    //Create a very basic PDF using a MemoryStream
    using (var ms = new MemoryStream()) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                doc.Open();
                doc.Add(new Paragraph("Hello World"));
                doc.Close();
            }
        }
        //When the "PDF stuff" is done but before we dispose of the MemoryStream, grab the raw bytes
        bytes = ms.ToArray();
    }
    
    //At this exact point, the variable "bytes" is an array of bytes that
    //represents a PDF. This could be sent to the browser via Response.BinaryWrite(bytes).
    //It could also be written to disk using System.IO.File.WriteAllBytes(myFilePath, bytes).
    //It could also be read back into a PdfReader directly via the code below
    //Create a new PDF based on the old PDF
    using (var ms = new MemoryStream()) {
        //Bind a reader to our previously created array
        using (var reader = new PdfReader(bytes)) {
            //Very simple stamper, could be much more complex, just draws a rectangle
            using (var stamper = new PdfStamper(reader, ms)) {
                var cb = stamper.GetOverContent(1);
                cb.Rectangle(50, 50, 200, 200);
                cb.SetColorFill(BaseColor.RED);
                cb.Fill();
            }
        }
        //Once again, grab the bytes before closing the MemoryStream but after the "PDF stuff"
        bytes = ms.ToArray();
    }
    //Once again, the "bytes" variable represents a PDF at this point
    //The above can be repeated as many times as needed

    public static void RemoveAcroFields(String filename)
        {
            if (filename != null && File.Exists(filename))
            {                
                byte[] pdfFile = File.ReadAllBytes(filename);
                PdfReader reader = new PdfReader(pdfFile);
                PdfStamper stamper = new PdfStamper(reader, new FileStream(filename, FileMode.Create));
                
                stamper.FormFlattening = true;
                stamper.Close();                                             
                                   
                reader.Close();
            }              
        }

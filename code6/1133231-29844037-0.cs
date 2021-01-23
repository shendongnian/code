         static void Main(string[] args)
            {
                var reader = new PdfReader(@"C:\x.pdf");
                FileStream outStream = new FileStream(@"C:\x_new.pdf", FileMode.Create);
    
                PdfDictionary page;
    
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    page = reader.GetPageN(i);
    
                    PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
    
                    if (rotate.IntValue != 0)
                    {
                        Console.WriteLine("Rotated page found");
                        page.Put(PdfName.ROTATE, new PdfNumber(0));
                    }
                    else
                        Console.WriteLine("This page is not rotated");
    
    
                }
    
                PdfStamper stamp = new PdfStamper(reader, outStream);
    
                stamp.Close();
                reader.Close();
                outStream.Close();
    
                Console.Read();
    }

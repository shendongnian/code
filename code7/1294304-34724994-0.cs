     using (var stream = new FileStream(PDFName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    writer.SetFullCompression();
                    document.Open();
                FileSystemInfo[] filez = d.GetFileSystemInfos();
                var filesInOrder = filez.OrderBy(f => f.CreationTime);
                foreach (var files in filesInOrder)
                    {
                        using (var imageStream = new FileStream(files.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            Image image = Image.GetInstance(imageStream);
                            image.ScaleToFit(PageSize.A4);
                            document.NewPage();
                            document.Add(image);
                     
                        }
                }
                document.Close();
            } 

    private void button1_Click(object sender, System.EventArgs e)
                {
                    string theDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\files\";
        
                    // Create test PDF
        
                    using (Doc doc = new Doc())
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            doc.Page = doc.AddPage();
                            doc.AddHtml("<font size=24>PAGE " + i.ToString());
                        }
                        doc.Save(Path.Combine(theDir, "test.pdf"));
                    }
        
                    // Save PDF pages to GIF streams
        
                    using (Doc doc = new Doc())
                    {
                        doc.Read(Path.Combine(theDir, "test.pdf"));
                        for (int i = 1; i <= doc.PageCount; i++)
                        {
                            doc.PageNumber = i;
                            doc.Rect.String = doc.CropBox.String;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                doc.Rendering.Save("dummy.gif", ms);
                                using (FileStream fs = File.Create(Path.Combine(theDir, "p" + i.ToString() + ".gif")))
                                {
                                    ms.Seek(0, SeekOrigin.Begin);
                                    ms.CopyTo(fs);
                                }
                            }
                        }
                    }
                }

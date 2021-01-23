                using (Bitmap b = new Bitmap(filePath))
                {
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.FillRectangle(Brushes.White, 0, 0, 105, 40);
                        var outputFileName = string.Concat(newPath, filename);
                        MemoryStream memory = new MemoryStream();
                        FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite);
                        b.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                        memory.Close();
                        b.Dispose();
                    }
                }

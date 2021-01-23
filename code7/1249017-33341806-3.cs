            foreach (var path in files)
            {
                var filename = Path.GetFileName(path);
                var filePath = string.Concat(tmpPath, filename);
                using (var b = new Bitmap(filePath))
                using (var g = Graphics.FromImage(b))
                {
                    g.FillRectangle(Brushes.White, 0, 0, 105, 40);
                    var outputFileName = string.Concat(newPath, filename);
                    using (var memory = new MemoryStream())
                    using (var fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        b.Save(memory, ImageFormat.Jpeg);
                        var bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                File.Delete(path);
            }

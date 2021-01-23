    /// <summary>
    /// Create sample images in the folder provided
    /// </summary>
    /// <param name="count">The number of images to create</param>
    /// <param name="workingFolder">The folder to create images in</param>
    private void createSampleImages(int count, string workingFolder) {
        var random = new Random();
        for (var i = 0; i < count; i++) {
            using (var bmp = new System.Drawing.Bitmap(200, 200)) {
                using (var g = System.Drawing.Graphics.FromImage(bmp)) {
                    g.Clear(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                }
                bmp.Save(System.IO.Path.Combine(workingFolder, string.Format("Image_{0}.jpg", i)));
            }
        }
    }
    /// <summary>
    /// Create sample PDFs in the folder provided
    /// </summary>
    /// <param name="count">The number of PDFs to create</param>
    /// <param name="workingFolder">The folder to create PDFs in</param>
    private void createSamplePDFs(int count, string workingFolder) {
        var random = new Random();
        for (var i = 0; i < count; i++) {
            using (var ms = new System.IO.MemoryStream()) {
                using (var doc = new Document()) {
                    using (var writer = PdfWriter.GetInstance(doc, ms)) {
                        doc.Open();
                        var pageCount = random.Next(1, 10);
                        for (var j = 0; j < pageCount; j++) {
                            doc.NewPage();
                            doc.Add(new Paragraph(String.Format("This is page {0} of document {1}", j, i)));
                        }
                        doc.Close();
                    }
                }
                System.IO.File.WriteAllBytes(System.IO.Path.Combine(workingFolder, string.Format("File_{0}.pdf", i)), ms.ToArray());
            }
        }
    }

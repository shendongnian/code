    Size size = fileCount > 2 ? new Size(66, 200) : new Size(100, 200);
    using (Image original = Image.FromFile(file.FullName))
    using (Image resized = ResizeImage(original, size))
    {
         resized.Save(newFullUploadPath, ImageFormat.Jpeg);
    }

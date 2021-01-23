    using(Bitmap image = GenerateThumbnail(url, 1024, 700, 600, 500))
    {
        image.Save(
            string.Format("{0}{1}/{2}-medium.jpg", filepath, folderName, form.FormId),
            System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    using(var stream = new System.IO.MemoryStream())
    {
        Bitmap qr = CreateCode(false);
        qr.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
        MailMessage mail = new MailMessage();
        Attachment a = new Attachment(stream,'myBitmap.bmp',MediaTypeNames.Image.Bmp);
    }

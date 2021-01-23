    // Instead of this:
    using (MemoryStream ms = new MemoryStream())
    {
      TheLocalSellerRepo.GetConvertedPDFImage().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
      base64 = System.Convert.ToBase64String(ms.ToArray());
    }
    // Should you be doing this:
    using (MemoryStream ms = new MemoryStream())
    {
      using (Image img = TheLocalSellerRepo.GetConvertedPDFImage())
      {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        base64 = System.Convert.ToBase64String(ms.ToArray());
      }
    }
    // Or you could even do this (if GetConvertedPDFImage() returns a MagickImage):
    using (MagickImage img = TheLocalSellerRepo.GetConvertedPDFImage())
    {
      img.Format = MagickFormat.Jpeg;
      base64 = img.ToBase64();
    }

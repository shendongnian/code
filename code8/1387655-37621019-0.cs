    Image i = Image.FromFile("C:\\image\\Tif_Document.tif");
    i.SelectActiveFrame(FrameDimension.Page, currentPrintPage);
    using (MemoryStream ms = new MemoryStream()) {
      i.Save(ms, ImageFormat.Tiff);
      using (Image pageImage = Image.FromStream(ms)) {
        var img = ResizeAcordingToImage(pageImage, img_width, img_height);
        e.Graphics.DrawImage(pageImage, e.MarginBounds.Left, e.MarginBounds.Top,
                                        img.Width, img.Height);
      }
    }

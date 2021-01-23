     public void ConvertHtmlToImage()
    {
      Bitmap m_Bitmap = new Bitmap(400, 600);
      PointF point = new PointF(0, 0);
      SizeF maxSize = new System.Drawing.SizeF(500, 500);
      HtmlRenderer.HtmlRender.Render(Graphics.FromImage(m_Bitmap),html,point, maxSize); //html is the varialbe obtained above
      m_Bitmap.Save(@"C:\Test.png", ImageFormat.Png);
    }

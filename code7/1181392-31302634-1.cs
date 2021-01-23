    private System.Drawing.Font GetFontFromResource()
    {
     Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("yourfont.ttf");
    
          byte[] fontdata = new byte[fontStream.Length];
          fontStream.Read(fontdata,0,(int)fontStream.Length);
          fontStream.Close();
          unsafe
          {
            fixed(byte * pFontData = fontdata)
            {
              return new  System.Drawing.Font((System.IntPtr)pFontData, 16, FontStyle.Regular);
            }
          }
    }

          public static class MyExtensions
          {
              public static Byte[] ByteFromImage(this System.Windows.Media.Imaging.BitmapImage imageSource)
              {
                Stream stream = imageSource.StreamSource;
                Byte[] imagebyte = null;
                if (stream != null && stream.Length > 0)
                {
                   using (BinaryReader br = new BinaryReader(stream))
                   {
                     imagebyte = br.ReadBytes((Int32)stream.Length);
                   }
                }
                  return imagebyte;
              }
           }

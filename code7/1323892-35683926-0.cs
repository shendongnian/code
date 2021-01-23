     public static class Converter
     {
       public static byte[] BitmapImage2ByteArray(BitmapImage bmp)
       {
         MemoryStream stream = new MemoryStream();
         BmpBitmapEncoder encoder = new BmpBitmapEncoder();
         encoder.Frames.Add(BitmapFrame.Create(bmp));
         encoder.Save(stream);
         stream.Flush();
         return stream.ToArray();
       }
       public static void BytesArray2BitmapImage(BitmapImage bmp, byte[] buffer)
       {
         MemoryStream stream = new MemoryStream(buffer);
         stream.Seek(0, SeekOrigin.Begin);
         bmp.BeginInit();
         bmp.StreamSource = stream;
         bmp.EndInit();
       }
    }

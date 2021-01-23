      public static void GetAndSaveImage(byte[] buffer, int offset, int count,string path)
      {
          using(var memoryStream = new MemoryStream(buffer, offset, count))
          using(var img = Image.FromStream(memoryStream))
          {
              img.Save(path);
          }
      }

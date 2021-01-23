    public static MemoryStream GetStream(this FileStream source)
    {
         using(MemoryStream stream = new MemoryStream())
         {
              source.CopyTo(stream);
              return stream;
         }
    }

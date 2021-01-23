      using (var memoryStream = new System.IO.MemoryStream())
       {
              file.GetStream().CopyTo(memoryStream);
           // file.Dispose();
              byte[] ImageBytes  = memoryStream.ToArray();
      }

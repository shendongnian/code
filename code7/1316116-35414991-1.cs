    var data = new float[10 * 1024];
    var helperBuffer = new byte[4096];
    
    using (var fs = File.Create(@"D:\Temp.bin"))
    using (var ms = new MemoryStream(4096))
    using (var bw = new BinaryWriter(ms))
    {
      var iteration = 0;
      
      foreach (var sample in data)
      {
        bw.Write(sample);
      
        iteration++;
        
        if (iteration == 1024)
        {
          iteration = 0;
          ms.Position = 0;
          
          ms.Read(helperBuffer, 0, 1024 * 4);
          await fs.WriteAsync(helperBuffer, 0, 1024 * 4).ConfigureAwait(false);
        }
      }
    }

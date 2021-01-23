       public Byte[] Encode(Byte[] input)
       {
           Byte[] output = null;
           using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(input))
           using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
           using (BrotliStream bs = new BrotliStream(msOutput, System.IO.Compression.CompressionMode.Compress))
           {
               bs.SetQuality(11);
               bs.SetWindow(22);
               msInput.CopyTo(bs);
               msOutput.Seek(0, System.IO.SeekOrigin.Begin);
               bs.Close();
               output = msOutput.ToArray();
               return output;
           }
       }

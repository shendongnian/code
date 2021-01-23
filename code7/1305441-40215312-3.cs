       public Byte[] Decode(Byte[] input)
       {
           using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(input))
           using (BrotliStream bs = new BrotliStream(msInput, System.IO.Compression.CompressionMode.Decompress))
           using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
           {
               bs.CopyTo(msOutput);
               msOutput.Seek(0, System.IO.SeekOrigin.Begin);
               output = msOutput.ToArray();
               return output;
           }
       }

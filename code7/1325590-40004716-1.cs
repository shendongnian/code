     List<byte[]> arrays = new List<byte[]>();
     const int size = int.MaxValue/2;
     const int sizeMB = size / 1024 / 1024;
     for(int step = 0; step < 10000; step++)
     {
         using (new MemoryFailPoint(sizeMB))
         {
             arrays.Add(new byte[size]);
         }
     }

    unsafe
    {
        byte* line = (byte*)bitmapData.Scan0;
        for (int y = 0; y < data.Height; y++)
        {
            for (int x = 0; x < data.Width; x++)
            {
                byte* pos = line + x * 3;
                int pixel = Color.FromArgb(pos[0], pos[1], pos[2]).ToArgb();
                // do whatever
             }
             line += data.Stride;
         }
     }

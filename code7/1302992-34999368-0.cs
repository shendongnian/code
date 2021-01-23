    BitmapData bitmapData = bmp.LockBits(
        new Rectangle(0, 0, channelId[0].Count, channelId.Length),
        ImageLockMode.ReadWrite,
        PixelFormat.Format32bppArgb
    );
    unsafe{
     ColorARGB* startingPosition = (ColorARGB*) bitmapData.Scan0;
     for (int y = 0; y < channelId.Length; y++) {
            for (int x = 0; x < channelId[y].Count; x++) {
                int myColor = (channelId[y].ElementAt(x) * 255) / 1000;
                if (myColor > 255) {
                    myColor = 255;
                } else if (myColor < 0) {
                    myColor = 0;
                }
               
                ColorARGB* position = startingPosition + j + i * channelId[0].Count;
                position->A = 255;
                position->R = myColor;
                position->G = myColor;
                position->B = myColor;
            }
        }
        bmp.UnlockBits(bitmapData);
       }

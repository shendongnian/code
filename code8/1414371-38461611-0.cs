    [HandleProcessCorruptedStateExceptions]
    private void saveImage(byte[] bmpBytes)
    {
        try {
         Debug.Print("Image saving started");
         var arrayHandle = System.Runtime.InteropServices.GCHandle.Alloc(bmpBytes, System.Runtime.InteropServices.GCHandleType.Pinned);
         System.Drawing.Image bmp = new System.Drawing.Bitmap(960, 540, 960 * 3, PixelFormat.Format24bppRgb, arrayHandle.AddrOfPinnedObject());
         bmp.Save("img.bmp");
         Debug.Print("Image saving completed");
        } catch ( System.AccessViolationException ex ) {
             // Doing smth
        }

    unsafe bool ArePixelsEqual(byte* p1, byte* p2, int bytesPerPixel)
    {
        for (int i = 0; i < bytesPerPixel; ++i)
            if (p1[i] != p2[i])
                return false;
        return true;
    }
    private unsafe List<Rectangle> CodeImage(Bitmap bmp, Bitmap bmp2)
    {
        if (bmp.PixelFormat != bmp2.PixelFormat || bmp.Width != bmp2.Width || bmp.Height != bmp2.Height)
            throw new ArgumentException();
        List<Rectangle> rec = new List<Rectangle>();
        var bmData1 = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        var bmData2 = bmp2.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp2.PixelFormat);
        int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
        IntPtr scan01 = bmData1.Scan0;
        IntPtr scan02 = bmData2.Scan0;
        int stride1 = bmData1.Stride;
        int stride2 = bmData2.Stride;
        int nWidth = bmp.Width;
        int nHeight = bmp.Height;
        HashSet<Point> processedPixels = new HashSet<Point>();
        byte* base1 = (byte*)scan01.ToPointer();
        byte* base2 = (byte*)scan02.ToPointer();
        for (int y = 0; y < nHeight; y++)
        {
            byte* p1 = base1;
            byte* p2 = base2;
            for (int x = 0; x < nWidth; ++x )
            {
                if(!ArePixelsEqual(p1, p2, bytesPerPixel) && !processedPixels.Contains(new Point(x, y)))
                {
                    // fill the different area
                    int minX = x;
                    int maxX = x;
                    int minY = y;
                    int maxY = y;
                    var pt = new Point(x, y);
                    Stack<Point> toBeProcessed = new Stack<Point>();
                    processedPixels.Add(pt);
                    toBeProcessed.Push(pt);
                    while(toBeProcessed.Count > 0)
                    {
                        var process = toBeProcessed.Pop();
                        var ptr1 = (byte*)scan01.ToPointer() + process.Y * stride1 + process.X * bytesPerPixel;
                        var ptr2 = (byte*)scan02.ToPointer() + process.Y * stride2 + process.X * bytesPerPixel;
                        //Check pixel equality
                        if (!(process.X >= 0 && process.X < nWidth &&
                            process.Y >= 0 && process.Y < nHeight) ||
                            ArePixelsEqual(ptr1, ptr2, bytesPerPixel))
                            continue;
                        //This pixel is different
                        //Update the rectangle
                        if (process.X < minX) minX = process.X;
                        if (process.X > maxX) maxX = process.X;
                        if (process.Y < minY) minY = process.Y;
                        if (process.Y > maxY) maxY = process.Y;
                        //Put neighbors in stack
                        var n = new Point(process.X - 1, process.Y);
                        if (!processedPixels.Contains(n)) { processedPixels.Add(n); toBeProcessed.Push(n); }
                        n = new Point(process.X + 1, process.Y);
                        if (!processedPixels.Contains(n)) { processedPixels.Add(n); toBeProcessed.Push(n); }
                        n = new Point(process.X, process.Y - 1);
                        if (!processedPixels.Contains(n)) { processedPixels.Add(n); toBeProcessed.Push(n); }
                        n = new Point(process.X, process.Y + 1);
                        if (!processedPixels.Contains(n)) { processedPixels.Add(n); toBeProcessed.Push(n); }
                    }
                    rec.Add(new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1));
                }
                p1 += bytesPerPixel;
                p2 += bytesPerPixel;
            }
            base1 += stride1;
            base2 += stride2;
        }
        return rec;
    }

    public static Bitmap RemoveAlphaChannel(Bitmap bitmapSrc) {
        Rectangle rect = new Rectangle(0, 0, bitmapSrc.Width, bitmapSrc.Height);
        Bitmap bitmapDest = (Bitmap)new Bitmap(bitmapSrc.Width, bitmapSrc.Height, PixelFormat.Format24bppRgb);
        BitmapData dataSrc = bitmapSrc.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        BitmapData dataDest = bitmapDest.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        NativeMethods.CopyMemory(dataDest.Scan0, dataSrc.Scan0, (uint)dataSrc.Stride * (uint)dataSrc.Height);
        bitmapSrc.UnlockBits(dataSrc);
        bitmapDest.UnlockBits(dataDest);
        return bitmapDest;
    }
    static class NativeMethods {
        const string KERNEL32 = "Kernel32.dll";
        [DllImport(KERNEL32)]
        public extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);
        
    }

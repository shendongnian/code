    class BitmapWithAccess
    {
        public Bitmap Bitmap { get; private set; }
        public System.Drawing.Imaging.BitmapData BitmapData { get; private set; }
 
        public BitmapWithAccess(Bitmap bitmap, System.Drawing.Imaging.ImageLockMode lockMode)
        {
            Bitmap = bitmap;
            BitmapData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), lockMode, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
 
        public Color GetPixel(int x, int y)
        {
            unsafe
            {
                byte* dataPointer = MovePointer((byte*)BitmapData.Scan0, x, y);
 
                return Color.FromArgb(dataPointer[3], dataPointer[2], dataPointer[1], dataPointer[0]);
            }
        }
 
        public void SetPixel(int x, int y, Color color)
        {
            unsafe
            {
                byte* dataPointer = MovePointer((byte*)BitmapData.Scan0, x, y);
 
                dataPointer[3] = color.A;
                dataPointer[2] = color.R;
                dataPointer[1] = color.G;
                dataPointer[0] = color.B;
            }
        }
 
        public void Release()
        {
            Bitmap.UnlockBits(BitmapData);
            BitmapData = null;
        }
 
        private unsafe byte* MovePointer(byte* pointer, int x, int y)
        {
            return pointer + x * 4 + y * BitmapData.Stride;
        }
    }

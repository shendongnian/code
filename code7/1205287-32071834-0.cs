        int all_count = 0;
        Bitmap _desktop = null;
        Bitmap _merged_bitmap = new Bitmap(1600, 900);
        int _height_part_ = 0;
        int _total_rows = 10;
        Bitmap[] crops = null;
        Bitmap[] _new_crops = null;
        Stopwatch sw = new Stopwatch();
        int _desktop_height = 0;
        int _desktop_width = 0;
        ImageManipulation.OctreeQuantizer _q ;
        RLC.RemoteDesktop.ScreenCapture cap = new RLC.RemoteDesktop.ScreenCapture();
       private void CaptureAndSend()
        {
            sw.Restart();
            //cap = new RLC.RemoteDesktop.ScreenCapture();
            int _left = -1, _top = -1; //Changed regions
            _desktop = cap.Screen(out _left, out _top); //Capture desktop or changed region of it
            if (_desktop == null) return; //if nothing has changed since last capture skip everything
            _desktop_height = _desktop.Height;
            _desktop_width = _desktop.Width;
            // If very small part has changed since last capture skip everything
            if (_desktop_height < 10 || _desktop_width < 10) return; 
            TotalRows(_total_rows); // Calculate the total number of rows 
            crops = new Bitmap[_total_rows]; // Cropped pieces of image
            _new_crops = new Bitmap[_total_rows];
            for (int i = 0; i < _total_rows - 1; i++) //Take whole image and split it into smaller images
                crops[i] = CropRow(i);
            crops[_total_rows - 1] = CropLastRow(_total_rows - 1);
            
            Parallel.For(0, _total_rows, i =>
            {
                ImageManipulation.OctreeQuantizer _q = new ImageManipulation.OctreeQuantizer(255, 4); // Initialize Octree
                _new_crops[i] = _q.Quantize(crops[i]);
                using (MemoryStream ms=new MemoryStream())
                { 
                    _new_crops[i].Save(ms, ImageFormat.Png);
                    //Install-Package LZ4.net
                    //Compress each part and send them over network
                    byte[] data = Lz4Net.Lz4.CompressBytes(ms.ToArray(), Lz4Net.Lz4Mode.HighCompression);
                    all_count += data.Length; //Just to check the final size of image
                }                  
            });
        
            Console.WriteLine(String.Format("{0:0.0} FPS , {1} seconds , size {2} kb", 1.0 / sw.Elapsed.TotalSeconds, sw.Elapsed.TotalSeconds.ToString(), all_count / 1024));
            all_count = 0;
        }
        private void TotalRows(int parts)
        {
            _height_part_ = _desktop_height / parts;
        }
        private Bitmap CropRow(int row)
        {
            return Crop(_desktop, new Rectangle(0, row * _height_part_, _desktop_width, _height_part_));
        }
        private Bitmap CropLastRow(int row)
        {
            return Crop(_desktop, new Rectangle(0, row * _height_part_, _desktop_width, _desktop_height - (row * _height_part_)));
        }
     [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern int memcpy(byte* dest, byte* src, long count);
        private unsafe Bitmap Crop(Bitmap srcImg, Rectangle rectangle)
        {
            if ((srcImg.Width == rectangle.Width) && (srcImg.Height == rectangle.Height))
                return srcImg;
            var srcImgBitmapData = srcImg.LockBits(new Rectangle(0, 0, srcImg.Width, srcImg.Height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
            var bpp = srcImgBitmapData.Stride / srcImgBitmapData.Width; // 3 or 4
            var srcPtr = (byte*)srcImgBitmapData.Scan0.ToPointer() + rectangle.Y * srcImgBitmapData.Stride + rectangle.X * bpp;
            var srcStride = srcImgBitmapData.Stride;
            var dstImg = new Bitmap(rectangle.Width, rectangle.Height, srcImg.PixelFormat);
            var dstImgBitmapData = dstImg.LockBits(new Rectangle(0, 0, dstImg.Width, dstImg.Height), ImageLockMode.WriteOnly, dstImg.PixelFormat);
            var dstPtr = (byte*)dstImgBitmapData.Scan0.ToPointer();
            var dstStride = dstImgBitmapData.Stride;
            for (int y = 0; y < rectangle.Height; y++)
            {
                memcpy(dstPtr, srcPtr, dstStride);
                srcPtr += srcStride;
                dstPtr += dstStride;
            }
            srcImg.UnlockBits(srcImgBitmapData);
            dstImg.UnlockBits(dstImgBitmapData);
            return dstImg;
        }

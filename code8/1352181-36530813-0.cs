    public class DistanceTransform2
    {
        /// <summary>  
        /// Distance transform for binary image.  
        /// </summary>  
        /// <param name="src">The source image.</param>  
        /// <param name="distanceMode">One parameter to choose the mode of distance transform from 1 to 3, 1 means Euclidean Distance, 2 means CityBlock Distance, 3 means ChessBoard Distance.</param>  
        /// <returns>The result image.</returns>  
        public Bitmap DistanceTransformer(Bitmap src, int distanceMode)
        {
            int w = src.Width;
            int h = src.Height;
            double p0 = 0, p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, min = 0;
            int mMax = 0, mMin = 255;
            System.Drawing.Imaging.BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)srcData.Scan0.ToPointer();
                int stride = srcData.Stride;
                byte* pTemp;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if (x > 0 && x < w - 1 && y > 0 && y < h - 1)
                        {
                            p0 = (p + x * 3 + y * stride)[0];
                            if (p0 != 0)
                            {
                                pTemp = p + (x - 1) * 3 + (y - 1) * stride;
                                p2 = pTemp[0] + GetDistance(x, y, x - 1, y - 1, distanceMode);
                                pTemp = p + x * 3 + (y - 1) * stride;
                                p3 = pTemp[0] + GetDistance(x, y, x, y - 1, distanceMode);
                                pTemp = p + (x + 1) * 3 + (y - 1) * stride;
                                p4 = pTemp[0] + GetDistance(x, y, x + 1, y - 1, distanceMode);
                                pTemp = p + (x - 1) * 3 + y * stride;
                                p1 = pTemp[0] + GetDistance(x, y, x - 1, y, distanceMode);
                                min = GetMin(p0, p1, p2, p3, p4);
                                pTemp = p + x * 3 + y * stride;
                                pTemp[0] = (byte)Math.Min(min, 255);
                                pTemp[1] = (byte)Math.Min(min, 255);
                                pTemp[2] = (byte)Math.Min(min, 255);
                            }
                        }
                        else
                        {
                            pTemp = p + x * 3 + y * stride;
                            pTemp[0] = 0;
                            pTemp[1] = 0;
                            pTemp[2] = 0;
                        }
                    }
                }
                for (int y = h - 1; y > 0; y--)
                {
                    for (int x = w - 1; x > 0; x--)
                    {
                        if (x > 0 && x < w - 1 && y > 0 && y < h - 1)
                        {
                            p0 = (p + x * 3 + y * stride)[0];
                            if (p0 != 0)
                            {
                                pTemp = p + (x + 1) * 3 + y * stride;
                                p5 = pTemp[0] + GetDistance(x, y, x + 1, y, distanceMode);
                                pTemp = p + (x + 1) * 3 + (y + 1) * stride;
                                p6 = pTemp[0] + GetDistance(x, y, x + 1, y + 1, distanceMode);
                                pTemp = p + x * 3 + (y + 1) * stride;
                                p7 = pTemp[0] + GetDistance(x, y, x, y + 1, distanceMode);
                                pTemp = p + (x - 1) * 3 + (y + 1) * stride;
                                p8 = pTemp[0] + GetDistance(x, y, x - 1, y + 1, distanceMode);
                                min = GetMin(p0, p5, p6, p7, p8);
                                pTemp = p + x * 3 + y * stride;
                                pTemp[0] = (byte)Math.Min(min, 255);
                                pTemp[1] = (byte)Math.Min(min, 255);
                                pTemp[2] = (byte)Math.Min(min, 255);
                                mMax = (int)Math.Max(min, mMax);
                            }
                        }
                        else
                        {
                            pTemp = p + x * 3 + y * stride;
                            pTemp[0] = 0;
                            pTemp[1] = 0;
                            pTemp[2] = 0;
                        }
                    }
                }
                mMin = 0;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        pTemp = p + x * 3 + y * stride;
                        if (pTemp[0] != 0)
                        {
                            int temp = pTemp[0];
                            pTemp[0] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                            pTemp[1] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                            pTemp[2] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                        }
                    }
                }
                src.UnlockBits(srcData);
                return src;
            }
        }
        /// <summary>  
        /// Chamfer distance transform(using two 3*3 windows:forward window434 300 000;backward window 000 003 434).  
        /// </summary>  
        /// <param name="src">The source image.</param>  
        /// <returns>The result image.</returns>  
        public Bitmap ChamferDistancetransfrom(Bitmap src)
        {
            int w = src.Width;
            int h = src.Height;
            double p0 = 0, p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, min = 0;
            int mMax = 0, mMin = 255;
            System.Drawing.Imaging.BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)srcData.Scan0.ToPointer();
                int stride = srcData.Stride;
                byte* pTemp;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if (x > 0 && x < w - 1 && y > 0 && y < h - 1)
                        {
                            p0 = (p + x * 3 + y * stride)[0];
                            if (p0 != 0)
                            {
                                pTemp = p + (x - 1) * 3 + (y - 1) * stride;
                                p2 = pTemp[0] + 4;
                                pTemp = p + x * 3 + (y - 1) * stride;
                                p3 = pTemp[0] + 3;
                                pTemp = p + (x + 1) * 3 + (y - 1) * stride;
                                p4 = pTemp[0] + 4;
                                pTemp = p + (x - 1) * 3 + y * stride;
                                p1 = pTemp[0] + 3;
                                min = GetMin(p0, p1, p2, p3, p4);
                                pTemp = p + x * 3 + y * stride;
                                pTemp[0] = (byte)Math.Min(min, 255);
                                pTemp[1] = (byte)Math.Min(min, 255);
                                pTemp[2] = (byte)Math.Min(min, 255);
                            }
                        }
                        else
                        {
                            pTemp = p + x * 3 + y * stride;
                            pTemp[0] = 0;
                            pTemp[1] = 0;
                            pTemp[2] = 0;
                        }
                    }
                }
                for (int y = h - 1; y > 0; y--)
                {
                    for (int x = w - 1; x > 0; x--)
                    {
                        if (x > 0 && x < w - 1 && y > 0 && y < h - 1)
                        {
                            p0 = (p + x * 3 + y * stride)[0];
                            if (p0 != 0)
                            {
                                pTemp = p + (x + 1) * 3 + y * stride;
                                p5 = pTemp[0] + 3;
                                pTemp = p + (x + 1) * 3 + (y + 1) * stride;
                                p6 = pTemp[0] + 4;
                                pTemp = p + x * 3 + (y + 1) * stride;
                                p7 = pTemp[0] + 3;
                                pTemp = p + (x - 1) * 3 + (y + 1) * stride;
                                p8 = pTemp[0] + 4;
                                min = GetMin(p0, p5, p6, p7, p8);
                                pTemp = p + x * 3 + y * stride;
                                pTemp[0] = (byte)Math.Min(min, 255);
                                pTemp[1] = (byte)Math.Min(min, 255);
                                pTemp[2] = (byte)Math.Min(min, 255);
                                mMax = (int)Math.Max(min, mMax);
                            }
                        }
                        else
                        {
                            pTemp = p + x * 3 + y * stride;
                            pTemp[0] = 0;
                            pTemp[1] = 0;
                            pTemp[2] = 0;
                        }
                    }
                }
                mMin = 0;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        pTemp = p + x * 3 + y * stride;
                        if (pTemp[0] != 0)
                        {
                            int temp = pTemp[0];
                            pTemp[0] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                            pTemp[1] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                            pTemp[2] = (byte)((temp - mMin) * 255 / (mMax - mMin));
                        }
                    }
                }
                src.UnlockBits(srcData);
                return src;
            }
        }
        private double GetDistance(int x, int y, int dx, int dy, int mode)
        {
            double result = 0;
            switch (mode)
            {
                case 1:
                    result = EuclideanDistance(x, y, dx, dy);
                    break;
                case 2:
                    result = CityblockDistance(x, y, dx, dy);
                    break;
                case 3:
                    result = ChessboardDistance(x, y, dx, dy);
                    break;
            }
            return result;
        }
        private double EuclideanDistance(int x, int y, int dx, int dy)
        {
            return Math.Sqrt((x - dx) * (x - dx) + (y - dy) * (y - dy));
        }
        private double CityblockDistance(int x, int y, int dx, int dy)
        {
            return Math.Abs(x - dx) + Math.Abs(y - dy);
        }
        private double ChessboardDistance(int x, int y, int dx, int dy)
        {
            return Math.Max(Math.Abs(x - dx), Math.Abs(y - dy));
        }
        private double GetMin(double a, double b, double c, double d, double e)
        {
            return Math.Min(Math.Min(Math.Min(a, b), Math.Min(c, d)), e);
        }

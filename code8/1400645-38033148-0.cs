    public class ScreenCapture
    {
        protected System.Drawing.Bitmap capture_;
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maskFile">Optional mask file, use "" for no mask</param>
        public ScreenCapture( string maskFile )
        {
             // capture the screen
             capture_ = CaptureWindow(User32.GetDesktopWindow());
    
             // if there is a mask file, load it and apply it to the capture
             if (maskFile != "")
             {
                 string maskfilename = maskFile + ".png";
                 System.Drawing.Bitmap maskImage = System.Drawing.Image.FromFile(maskfilename) as Bitmap;
    
                 // ensure mask is same dim as capture...
                 if ((capture_.Width != maskImage.Width) || (capture_.Height != maskImage.Height))
                    throw new System.Exception("Mask image is required to be " + capture_.Width + " x " + capture_.Height + " RGBA for this screen capture");
    
                 Rectangle rectCapture = new Rectangle(0, 0, capture_.Width, capture_.Height);
                 Rectangle rectMask = new Rectangle(0, 0, maskImage.Width, maskImage.Height);
    
                 System.Drawing.Imaging.BitmapData dataCapture = capture_.LockBits(rectCapture, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                 System.Drawing.Imaging.BitmapData dataMask = maskImage.LockBits(rectCapture, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
                 IntPtr ptrCapture = dataCapture.Scan0;
                 IntPtr ptrMask = dataMask.Scan0;
    
                 int size = Math.Abs(dataCapture.Stride) * capture_.Height;
    
                 byte[] bitsCapture = new byte[size];
                 byte[] bitsMask = new byte[size];
    
                 System.Runtime.InteropServices.Marshal.Copy(ptrCapture, bitsCapture, 0, size);
                 System.Runtime.InteropServices.Marshal.Copy(ptrMask, bitsMask, 0, size);
                    
                 // check each pixel of the image... if the mask is 0 for each channel, set the capture pixel to 0.
                 for (int n = 0; n < size; n += 4)
                 {
                     bool clearPixel = true;
                     for ( int c = 0; c < 4; ++c )
                     {
                         // if any pixel of the mask is not black, do not clear the capture pixel
                         if (bitsMask[n + c] != 0)
                         {
                             clearPixel = false;
                             break;
                         }      
                    }
                    if ( clearPixel )
                    {
                        bitsCapture[n] = 0;
                        bitsCapture[n + 1] = 0;
                        bitsCapture[n + 2] = 0;
                        bitsCapture[n + 3] = 0;
                    }
                }
    
                System.Runtime.InteropServices.Marshal.Copy(bitsCapture, 0, ptrCapture, size);
                System.Runtime.InteropServices.Marshal.Copy(bitsMask, 0, ptrMask, size);
                capture_.UnlockBits(dataCapture);
                maskImage.UnlockBits(dataMask);
                }
            }
    
            /// <summary>
            /// Creates an Image object containing a screen shot of a specific window
            /// </summary>
            /// <param name="handle">The handle to the window. 
            /// (In windows forms, this is obtained by the Handle property)</param>
            /// <returns>Screen grab image</returns>
            private System.Drawing.Bitmap CaptureWindow(IntPtr handle)
            {
                // get te hDC of the target window
                IntPtr hdcSrc = User32.GetWindowDC(handle);
                
                // get the size
                User32.RECT windowRect = new User32.RECT();
                User32.GetWindowRect(handle, ref windowRect);
                int width = windowRect.right - windowRect.left;
                int height = windowRect.bottom - windowRect.top;
                
                // create a device context we can copy to
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                
                // select the bitmap object
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                
                // bitblt over
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                
                // restore selection
                GDI32.SelectObject(hdcDest, hOld);
                
                // clean up
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);
                
                // get a .NET image object for it
                System.Drawing.Bitmap img = System.Drawing.Image.FromHbitmap(hBitmap);
                
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);
                return img;
            }
    
            /// <summary>
            /// Save this capture as a Png image.
            /// </summary>
            /// <param name="filename">File path and name not including extension</param>
            public void SaveCapture( string filename )
            {
                capture_.Save(filename + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
    
            /// <summary>
            /// Helper class containing Gdi32 API functions
            /// </summary>
            private class GDI32
            {
                public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
                [DllImport("gdi32.dll")]
                public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                    int nWidth, int nHeight, IntPtr hObjectSource,
                    int nXSrc, int nYSrc, int dwRop);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                    int nHeight);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteObject(IntPtr hObject);
                [DllImport("gdi32.dll")]
                public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
            }
    
            /// <summary>
            /// Helper class containing User32 API functions
            /// </summary>
            private class User32
            {
                [StructLayout(LayoutKind.Sequential)]
                public struct RECT
                {
                    public int left;
                    public int top;
                    public int right;
                    public int bottom;
                }
                [DllImport("user32.dll")]
                public static extern IntPtr GetDesktopWindow();
                [DllImport("user32.dll")]
                public static extern IntPtr GetActiveWindow();
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowDC(IntPtr hWnd);
                [DllImport("user32.dll")]
                public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            }
        }

        public static BitmapSource ConvertToBitmapSource(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;
            //BitmapImage b=new BitmapImage();
            BitmapSource bitSrc = null;
            var hBitmap = IntPtr.Zero;
            try
            {
                hBitmap = bitmap.GetHbitmap();
                bitSrc = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
            catch (ArgumentException)
            {
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);
                hBitmap = IntPtr.Zero;
            }
            catch
            {
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);
                bitSrc = null;
                hBitmap = IntPtr.Zero;
            }
            finally
            {
                //bitmap.Dispose();
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);
            }
            return bitSrc;
        }
        
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr hObject);

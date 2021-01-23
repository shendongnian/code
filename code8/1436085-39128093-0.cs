        public static extern bool DeleteObject(IntPtr onj);
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Bitmap bitmap;
            bitmap = new Bitmap((int) SystemParameters.PrimaryScreenWidth,(int) SystemParameters.PrimaryScreenHeight,PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0,0,0,0,bitmap.Size);
            }
            IntPtr handle = IntPtr.Zero;
            try
            {
                handle = bitmap.GetHbitmap();
                ImageControl.Source = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                bitmap.Save("D:\\1.jpg"); //saving
            }
            catch (Exception)
            {
              
            }
            finally
            {
                DeleteObject(handle);
            }
        }

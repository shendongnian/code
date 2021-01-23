            using (Bitmap img = (Bitmap)Bitmap.FromFile(fileName))
            {
                IntPtr hBitmap = img.GetHbitmap();
                BitmapSource bitmap = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                DeleteObject(hBitmap);
            }

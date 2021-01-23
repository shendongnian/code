        private void UpdateCameraImage(object s, EventArgs e)
        {
            camera.GetMatImage(out currentImage);
            System.Drawing.Bitmap bitmap = currentImage.Bitmap;
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, ImageWidth, ImageHeight),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            cameraImageSource.CopyPixels(new Int32Rect(0, 0, ImageWidth, 
                ImageHeight), bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);
    
            bitmap.UnlockBits(bitmapData);
        }

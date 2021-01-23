        private void SaveCanvasAsImage()
        {
            Rect yourRect = new Rect(ccDraw.RenderSize);
            RenderTargetBitmap rtBitmap = new RenderTargetBitmap((int)yourRect.Right,
            (int)yourRect.Bottom, 100d, 100d, System.Windows.Media.PixelFormats.Default);
            rtBitmap.Render(ccDraw);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtBitmap));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pngEncoder.Save(ms);
            ms.Close();
            System.IO.File.WriteAllBytes("yourPng.png", ms.ToArray());
        }

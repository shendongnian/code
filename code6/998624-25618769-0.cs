    protected override void OnRender(DrawingContext context)
    {
        using (var bitmap = new GDI.Bitmap((int)RenderSize.Width, (int)RenderSize.Height))
        {
            using (var graphics = GDI.Graphics.FromImage(bitmap))
            {
                // use gdi functions here, to ex.: graphics.DrawLine(...)
            }
            var hbitmap = bitmap.GetHbitmap();
            var size = bitmap.Width * bitmap.Height * 4;
            GC.AddMemoryPressure(size);
            var image = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            image.Freeze();
            context.DrawImage(image, new Rect(RenderSize));
            DeleteObject(hbitmap);
            GC.RemoveMemoryPressure(size);
        }
    }

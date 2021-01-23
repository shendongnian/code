    using (var frame = BitmapImage2Bitmap(e.ColorFrame.BitmapImage))
        using (var thumb = ResizeBitmap(frame, 320, 240))
        {
             writer.WriteVideoFrame(thumb);
        }
    }

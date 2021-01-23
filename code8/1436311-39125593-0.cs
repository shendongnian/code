    void thread_function()
    {
        while (client != null)
        {
            ....some stuff...
            wrBitmap.WritePixels(rect, rgbch, rowLen, 0); // wrBitmap is WriteableBitmap
            wrBitmap.Freeze();
            Dispatcher.BeginInvoke((Action)(() => Image.Source = wrBitmap));
        }
    }

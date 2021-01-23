    try
    {
        lock (fileSystemWatcher)
        {
            var oldSource = source;
            var oldFrame = frame;
            source = new Image<Gray, byte>((Bitmap)Bitmap.FromFile(e.FullPath));
            frame = source.ThresholdBinary(new Gray(180), new Gray(255));
            if (oldSource != null)
                oldSource.Dispose();
           
            if (oldFrame != null)
                oldFrame.Dispose();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("File Loading Failed: " + ex.Message);
    }

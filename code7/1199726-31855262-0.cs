    private void SaveFrameworkElementToBitmap(FrameworkElement gridinput, string filepath)
    {
        gridinput.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
        int grid1Width = (int)Math.Round(gridinput.ActualWidth);
        int grid1Height = (int)Math.Round(gridinput.ActualHeight);
        grid1Width = grid1Width == 0 ? 1 : grid1Width;
        grid1Height = grid1Height == 0 ? 1 : grid1Height;
    
        RenderTargetBitmap rtbmp = new RenderTargetBitmap(grid1Width, grid1Height, 96d, 96d, PixelFormats.Default);
        rtbmp.Render(gridinput);
        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(rtbmp));
        FileStream gridbmpfilestrm = File.Create(filepath);
        encoder.Save(gridbmpfilestrm);
        gridbmpfilestrm.Close();
        rtbmp.Clear();
    }

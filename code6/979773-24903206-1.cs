    // simply pass the bitmap instance to the worker
    doImg.RunWorkerAsync(_bitmap);
    // worker method gets simplified a bit
    void doImg_DoWork(object sender, DoWorkEventArgs e)
    {
        var bip = new ImageProcessor.BasicImgPro();
        var bitmap = (Bitmap)e.Argument;
        var result = bip.HistoEqualize(bitmap);
        e.Result = result;
    }
    // convert to an image source when done
    void doImg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
            return;
        }
        
        imgDisp.Source = ConvertBitmapToImageSource((Bitmap)e.Result);
    }

    public CamNotification(string label1, string label2, BitmapSource image1, BitmapSource image2)
    
    private bool hwLink_SetInfos(CamNotification info)
    {
        try
        {
            info.Image1.Freeze();
            info.Image2.Freeze();
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                lblText1.Content = info.Label1;
                lblText2.Content = info.Label2;
    
                ImageBox1.Source = info.Image1;
                ImageBox2.Source = info.Image2;
                InvalidateVisual();
            }));
            return true;
        }
        catch (Exception ex)
        {
            Debugger.Break();
            return false;
        }
    }

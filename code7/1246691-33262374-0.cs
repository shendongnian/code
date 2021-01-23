    int mytest = 0;
    private async Task RefreshAsync()
    {
        var t1label = new UILabel(new RectangleF(10, 10, 200, 100));        
        View.Add(t1label);
        t1label.Font = UIFont.SystemFontOfSize(25);
        while (true)
        {
            t1label.Text = mytest.ToString();
            mytest++;
            await Task.Delay(30000);
        }
    }   

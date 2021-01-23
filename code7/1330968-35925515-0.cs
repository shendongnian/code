    public frmSelection()
    {
        InitializeComponent();
        wb.FrameLoadEnd += WebBrowserFrameLoadEnded;
        wb.Address = "http://www.racingpost.com/horses2/cards/card.sd?race_id=644222&r_date=2016-03-10#raceTabs=sc_";
    }
    private void WebBrowserFrameLoadEnded(object sender, FrameLoadEndEventArgs e)
    {
        if (e.Frame.IsMain)
        {
            wb.ViewSource();
            wb.GetSourceAsync().ContinueWith(taskHtml =>
            {
                var html = taskHtml.Result;
            });
        }
    }

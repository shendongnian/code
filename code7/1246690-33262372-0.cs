    int mytest = 0;
    // create the label outside of the loop
    var t1label = new UILabel(new RectangleF(10, 10, 200, 100));
    t1label.Text = mytest.ToString();
    View.Add(t1label);
    t1label.Font = UIFont.SystemFontOfSize(25);
    private async Task RefreshAsync()
    {
        while (0 == 0)
        {
          mytest++;
          t1label.Text = mytest.ToString();
          await Task.Delay(30000);
        }
    }   

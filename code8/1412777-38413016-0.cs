    public MainTabbedPage(bool requirePin)
    {
        if (requirePin)
        {
            Navigation.PushModalAsync(new PinEntryPage(this));
        }
        InitializeComponent();
    }
    public async void InitializeChildren()
    {
        try
        {
            var page1 = new Page1();
            await page1.RefreshData();
            var page2 = new Page2();
            await page2.RefreshButtons();
            await page2.RefreshData();
            var page3 = new Page3();
            await page3.RefreshData();
            Children.Add(page1);
            Children.Add(page2);
            Children.Add(page3);
        }
        catch (Exception ex)
        {
            // some error handling...
        }
    }

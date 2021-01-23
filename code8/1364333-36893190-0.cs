    public void SomeMethodToBeCalledOnLoad()
    {
        webKitBrowser1.Navigate("https://google.com");
    }
    public void Browser_Load(object sender, EventArgs e)
    {
        SomeMethodToBeCalledOnLoad();
    }
    public MainWindow(){
        ...
        Browser mBrowser = new Browser();
        Object sender = new Object();
        EventArgs e = new EventArgs();
        SomeMethodToBeCalledOnLoad();//here
        ...
    }

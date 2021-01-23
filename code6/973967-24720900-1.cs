    Form splash = new Form();
    
    public Form1()
    {
        InitializeComponent();
        this.Visible = false;
        splash.Opacity = 0;
        splash.Show();
        _timerShow();
        _timerHide();
        this.Visible = true;
    }
    
    private async void _timerShow()
    {
        while(splash.opacity!=1)
        {
            await Task.Delay(50);
            splash.opacity +=.01;
        }
    }
    
    private async void _timerHide()
    {
        while(splash.opacity!=0)
        {
            await Task.Delay(50);
            splash.opacity -=.01;
        }
    }

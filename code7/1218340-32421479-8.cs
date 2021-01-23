    public event EventHandler LoadCompleted;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.OnLoadCompleted(EventArgs.Empty);
    }
    protected virtual void OnLoadCompleted(EventArgs e)
    {
        var handler = LoadCompleted;
        if (handler != null)
            handler(this, e);
    }
    private void MainForm_Load(object sender, EventArgs e)
    {
        //Just for test, you can make a delay to simulate a time-consuming task
        //In a real application here you load your data and other settings
    }

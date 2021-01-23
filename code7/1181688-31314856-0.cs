    private Image purpleOk;
    private Image blueOk;
    public ErrorDialogForm()
    {
        InitializeComponent();
        purpleOk = Properties.Resources.purpleOkButton;
        blueOk = Properties.Resources.blueOkButton;
        pbOkButton.BackgroundImage = blueOk;
    }
    private void pbOkButton_MouseEnter(object sender, EventArgs e)
    {
        this.pbOkButton.BackgroundImage = purpleOk;
    }
    private void pbOkButton_MouseLeave(object sender, EventArgs e)
    {
        this.pbOkButton.BackgroundImage = blueOk;
    }
    protected override void OnFormClosed(FormClosedEventArgs e) 
    {
        purpleOk.Dispose();
        blueOk.Dispose();
        base.OnFormClosed(e);
    }

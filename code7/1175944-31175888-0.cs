    private bool isShowHideVisible;
    public bool IsShowHideVisible
    {
        get { return isShowHideVisible; }
        set
        {
            if(isShowHideVisible!=value)
            {
                isShowHideVisible = value;
            }
        }
    }
    public UserControl1()
    {
        InitializeComponent();
        this.DataContext=this;
    }
    private void OnPropertyChange(string pPropertyName)
    {
        if(PropertyChanged!=null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
}

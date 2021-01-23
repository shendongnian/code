    public MainPage()
    {
        myUserControl.MyPropertyChanged += MyUserControl_MyPropertyChanged;
    }
    private void MyUserControl_MyPropertyChanged(string a)
    {
        myTextBlock.Text = a;
    }

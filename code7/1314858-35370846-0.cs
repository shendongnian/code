    public RelayCommand YourCommand { get; set; }
    public YourViewModel()
    {
        NextCommand = new RelayCommand(DoSmth);
    }
    private void DoSmth(object obj)
    {
        Message.Box(obj.ToString()); 
    }

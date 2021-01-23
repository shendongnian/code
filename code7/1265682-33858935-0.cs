    private void NotifyPropertyChanged([CallerMemberName] string info = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
            MessageBox.Show(info);
        }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            NotifyPropertyChanged(); //now no need to specify
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string caller = "")
    {
        if (PropertyChanged != null)
         {
            PropertyChanged(this,
                     new PropertyChangedEventArgs(caller));
        }
    }

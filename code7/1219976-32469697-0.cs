    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged([CallerMemberName] string caller = "")
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
    }

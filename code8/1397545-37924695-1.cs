    private static int kills = 0;
    private static int Kills
    {
        get
        {
            return kills;
        }
        set
        {
            this.kills = value;
            this.OnPropertyChanged();
        }
    }
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
    {
        EventHandler pc = this.PropertyChanged;
        if (pc != null)
        {
            pc(this, new PropertyChangedEventArgs(propertyName));
        }
    }

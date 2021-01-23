    public void UpdateDayCase(int i, int j, DayCase)
    {
        this.DayCases[i][j] = DayCase;
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(DayCases)));
    }

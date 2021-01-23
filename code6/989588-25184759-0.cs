    public double Milliseconds
    {
        get { return milliseconds; }
        set
        {
            milliseconds = value;
            NotifyPropertyChanged("Milliseconds");
            yourTimer.Interval(TimeSpan.FromMilliseconds((int)milliseconds);
        }
    } 
...
    <Slider Value="{Binding Milliseconds}" ... />

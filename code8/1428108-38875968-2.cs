    public Color Color { get; set; } = Colors.Red;
    public string ColorText
    {
        get { return (new ColorConverter()).ConvertToString(Color); }
        set
        {
            Color = (Color)ColorConverter.ConvertFromString(value);
            OnPropertyChanged();
        }
    }

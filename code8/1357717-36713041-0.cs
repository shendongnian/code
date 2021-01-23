    /// <summary>
    /// Gets or sets if the button setFontBold is checked.
    /// </summary>
    private bool? setFontBoldIsChecked = false;
    public bool? SetFontBoldIsChecked
    {
        get { return setFontBoldIsChecked; }
        set
        {
            setFontBoldIsChecked = value;
            RaisePropertyChanged("SetFontBoldIsChecked");
            RaisePropertyChanged("TextFontWeight");
        }
    }
    /// <summary>
    /// Gets the fontweight depending on SetFontBoldIsChecked.
    /// </summary>
    private FontWeight textFontWeight;
    public FontWeight TextFontWeight
    {
        //get { return textFontWeight; }
        get
        {
            textFontWeight = (SetFontBoldIsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            return textFontWeight;
        }
        set
        {
            textFontWeight = value;
            RaisePropertyChanged("TextFontWeight");
        }
    }

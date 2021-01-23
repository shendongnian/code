    public bool IgnoreUpdate = false;
    public bool IgnoreUpdate
    {
        get
        {
            return ignoreUpdate;
        } set
        {
            ignoreUpdate = value;
            this.IgnoreUpdate = true;
            this.UpdateValue(value);
        }
    }
    public void UpdateValue(int ProgressValue)
    {
        this.Slider.Value = ProgressValue;
        if (IgnoreUpdate)
        {
            IgnoreUpdate = false;
            return;
        }
        //Do stuff when the value changes visually
        this.ValueWeCareAbout = ProgressValue;
    }
    private void Slider_ValueChanged(object sender, ProgessChangedEventArgs e)
    {
        this.UpdateValue(e.Value);
    }

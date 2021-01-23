    private bool IgnoreUpdate = false;
    private int value = 0;
    public int Value
    {
        get
        {
            return this.value;
        } set
        {
            this.value = value;
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
        this.Value = ProgressValue;
    }
    private void Slider_ValueChanged(object sender, ProgessChangedEventArgs e)
    {
        this.UpdateValue(e.Value);
    }

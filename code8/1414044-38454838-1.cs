    private string comboBoxText;
    public string ComboBoxText
    {
        get { return this.comboBoxText; }
        set
        {
            if (this.SetProperty(ref this.comboBoxText, value))
            {
                Trace.WriteLine("*** New text: " + value);
                // RunDatabaseSearch(value);
            }
        }
    }

    public MyTestForm()
    {
        InitializeComponent();
    
        SetDateTimePickerFirstOfMonth();
        UpdateTextbox();
    }
    
    private void SetDateTimePickerFirstOfMonth()
    {
        DateTime current = dtOtMonth.Value;
        if (current.Day != 1)
        {
            DateTime newValue = new DateTime(current.Year, current.Month, 1);
            dtOtMonth.Value = newValue;
        }
    }
    
    private void UpdateTextbox()
    {
        int year = dtOtMonth.Value.Year;
        int month = dtOtMonth.Value.Month;
    
        txtResult.Text = string.Format("Year is {0} and month is {1}", year, month);
    }
    
    private void dtOtMonth_ValueChanged(object sender, EventArgs e)
    {
        SetDateTimePickerFirstOfMonth();
        UpdateTextbox();
    }

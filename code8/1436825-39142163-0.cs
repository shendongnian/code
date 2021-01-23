    public myForm()
    {
        InitializeComponent();
        ....
        myDateTimePicker.Format = DateTimePickerFormat.Custom;
        myDateTimePicker.CustomFormat = "HH:mm"; //Shows only hours and minutes in 24h format
        myDateTimePicker.Value = DateTime.Now.Date; //sets the time to today at 0:00
        myDateTimePicker.MinDate = DateTime.Now.Date;
        myDateTimePicker.MaxDate = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59)); //User can't change date.
    }
    private DateTime newTime;
    private void myDateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        newTime = myDateTimePicker.Value.AddHours(8.5);
    }

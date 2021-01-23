    private void button1_Click(object sender, EventArgs e)
    {
        DateTimePicker1 = "MM/dd/yyyy hh:mm tt";
    
        DateTimePicker1 .Value = new DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
    }

        private void button2_Click(object sender, EventArgs e)
    {
        DateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm tt";
    
        DateTimePicker1.Value = new DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, 15, 23, 0);
    }

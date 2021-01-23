    private void timer2_Tick(object sender, EventArgs e)
    {
        DateTime Date = DateTimePickerReminderDate.Value;
        DateTime Time = DateTimePickerReminderTime.Value;
        if (DateTime.Now.CompareTo(Date) > 0 && DateTime.Now.CompareTo(Time) > 0) 
        {
            timer2.Stop();     
            Date = DateTime.MaxValue;
            Time = DateTime.MaxValue; 
            MessageBox.Show("Your Reminder");
        }
    }  

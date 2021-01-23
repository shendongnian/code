    private void timer_tick(object sender, EventArgs e)
    {
        string timeNow = DateTime.Now.ToString("hh:mm") + " " + DateTime.Now.ToString("tt");
       medicineAlarm(timeNow);
    }
    private void medicineAlarm(string timeNow)
    {
        DataTable dt = database.getSchedule();
        foreach (DataRow row in dt.Rows)
        {
            foreach(var label in new [] {"AM", "PM", "NN"})
                if (row[label + "Intake"].ToString() == timeNow)
                    {
                       MessageBox.Show("Drink Medicine");
                       return;
                    }
        }
    }

    private const TimeSpan saveTimeBeforeWarning = new TimeSpan(0,1,0); //1 minute 
    private static DateTime _lastSave = DateTime.Now;
       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if ((DateTime.Now - _lastSave) > saveTimeBeforeWarning)
        {
            if(MessageBox.Show("Would you like to save any changes before closing?") == DialogResult.Yes);
            {
                 Save();
            }
        }
    }
    private void Save()
    {
        //save data
        _lastSave = DateTime.Now
    }

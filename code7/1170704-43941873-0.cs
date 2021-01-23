    // set up the handlers in your code at initialize time
          checkBox_active.GotFocus += new System.EventHandler(this.checkBox_active_GotFocus);
          checkBox_active.LostFocus += new System.EventHandler(this.checkBox_active_LostFocus);
    
    // code to handle the events
        private void checkBox_active_GotFocus(object sender, EventArgs e)
        {
          checkBox_active.BackColor = Color.Red;
        }
        private void checkBox_active_LostFocus(object sender, EventArgs e)
        {
          checkBox_active.BackColor = Color.Gray;
        }

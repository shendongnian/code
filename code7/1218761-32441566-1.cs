                   private void scheduleBtn_Click(object sender, EventArgs e)
        {
            Schedule frm = new Schedule();
            frm.ShowDialog();
            if(frm.cbMonday.Checked)
            {
                runDay = "Monday";
            }
            else if(frm.cbTuesday.Checked)
            {
                runDay = "Tuesday";
            }
            else if(frm.cbWednesday.Checked)
            {
                runDay = "Wednesday";
            }
            else if(frm.cbThursday.Checked)
            {
                runDay = "Thursday";
            }
            else if(frm.cbFriday.Checked)
            {
                runDay = "Friday";
            }
            else if(frm.cbSaturday.Checked)
            {
                runDay = "Saturday";
            }
            else if(frm.cbSunday.Checked)
            {
                runDay = "Sunday";
            }
            dayLbl.Text = runDay;
        }

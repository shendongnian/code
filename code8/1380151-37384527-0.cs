    private void radActualSales_CheckedChanged(object sender, EventArgs e)
        {
            if (radActualSales.Checked == true)
            {
                startTimePicker.Enabled = true;                
                endTimePicker.Enabled = true;
            }
            else
            {
                startTimePicker.Enabled = false;
                //day, month, year, hour, minute, second
                startTimePicker.Value = new DateTime(1, 1, 1, 11, 59, 59);
                endTimePicker.Enabled = false;
                endTimePicker.Value. = new DateTime(1, 1, 1, 12, 0, 0);
            }
        }

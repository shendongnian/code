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
                startTimePicker.Value = DateTime.Today.AddHours(0);
                endTimePicker.Enabled = false;
                endTimePicker.Value = DateTime.Today.AddHours(-0.01);
                }
            }

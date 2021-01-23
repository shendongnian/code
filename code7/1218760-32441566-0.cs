        //
        //OK BUTTON
        //
        public void okBtn_Click(object sender, EventArgs e)
        {
            if (cbMonday.Checked)
            {
                day = "Monday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbTuesday.Checked)
            {
                day = "Tuesday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbWednesday.Checked)
            {
                day = "Wednesday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbThursday.Checked)
            {
                day = "Thursday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbFriday.Checked)
            {
                day = "Friday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbSaturday.Checked)
            {
                day = "Saturday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (cbSunday.Checked)
            {
                day = "Sunday";
                MessageBox.Show("BackUp Will Run Every " + day + " ", "Scheduled", MessageBoxButtons.OK);
                this.Close();
            }
            else if (string.IsNullOrWhiteSpace(day))
            {
                MessageBox.Show("You have not selected any days", "Woops");
            }
        }

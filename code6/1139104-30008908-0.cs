     private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
                if (this.checkBox4.Checked == true)
            {
                this.checkBox4.ForeColor = Color.Green;
                this.checkBox4.Text = "Max Parameters on set ON";
            }
              else if (this.checkBox4.Checked == false)
            {
                this.checkBox4.ForeColor = Color.Red;
                this.checkBox4.Text = "Max Parameters on set OFF";
            }
        }

    private void r_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton radio = sender as RadioButton;
    
                if (radio.Name == "r1")
                    MessageBox.Show("Radio 1 checked changed to: " + radio.Checked);
                else if (radio.Name == "r2")
                    MessageBox.Show("Radio 2 checked changed to: " + radio.Checked);
                else if (radio.Name == "r3")
                    MessageBox.Show("Radio 3 checked changed to: " + radio.Checked);
                else
                    MessageBox.Show("Unknow radio button");
            }

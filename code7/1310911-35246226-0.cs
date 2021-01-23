       private void ToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleButton.Checked)
                ToggleButton.BackgroundImage = Properties.Resources.ToggleButton_ON;
            else
                ToggleButton.BackgroundImage = Properties.Resources.ToggleButton_OFF;
        }

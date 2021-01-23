            public void ApplyDefaultColorToControls(Control parent)
            {
                foreach (Control currentControl in parent.Controls)
                {
                   if (colorSettings.ContainsKey(currentControl.Name) == true)
                   {
                    //Set the controls settings equal to their color in your stored dictionary
                    currentControl.BackColor = colorSettings[currentControl.Name].BackColor;
                    currentControl.ForeColor = colorSettings[currentControl.Name].ForeColor;
                   }
                   else
                   {
                    //Set the control settings equal to default settings
                    currentControl.BackColor = DefaultBackColor;
                    currentControl.ForeColor = DefaultForeColor;
                   }
                ApplyDefaultColorToControls(currentControl);
            }
        }

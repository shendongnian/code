    public void SaveFieldColors(Control parent, StreamWriter colorWriter)
        {
            foreach (Control currentControl in parent.Controls)
            {
                if (currentControl.ForeColor != DefaultForeColor || currentControl.BackColor != DefaultBackColor)
                {
                    //Save the file in your format
                    colorWriter.WriteLine(currentControl.Name + "," + currentControl.BackColor.ToArgb() + "," + currentControl.ForeColor.ToArgb());
                }
                ApplyDefaultColorToControls(currentControl);
            }
        }

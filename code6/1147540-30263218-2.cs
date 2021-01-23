    private void addButton_Click(object sender, EventArgs e)
    {
      /* as before... */
    
      int red = Convert.ToInt32(txtRed.Text);
      int green = Convert.ToInt32(txtGreen.Text);
      int blue = Convert.ToInt32(txtBlue.Text);
    
      newButton.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
    
      newButton.Click += (s, ea) => {
        //made up function call to show how you can use the rgb values inline here
        ArduinoController.SendRGB(red, green, blue);
      }
    }

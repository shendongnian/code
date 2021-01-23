    private void CreateSrsControls()
    {
      int xPos = 8;
      int yPos = 55;
 
     int height = 24;
    
      foreach (string srsPath in allSrs)
      {
          CheckBox cb = new CheckBox();
    
          cb.AutoSize = true;
          cb.Location = new Point(xPos, yPos);
    
          // friendly name
          cb.Text = Utilities.GetSrsGroupName(srsPath);
    
          // store full name for returning to caller
          cb.Tag = srsPath;
    
          cb.Checked = true;
          
          // NEW CODE
          cb.CheckChanged += CheckedOptionChanged;
          grpSrs.Controls.Add(cb);
          checkBoxes.Add(cb);
    
          yPos += height;
        }
      }
    private void CheckedOptionChanged(object sender, EventArgs e)
    {
      if (sender == cbAll)
      {
        foreach (var cb in checkBoxes)
        {
          cb.Checked = cbAll.Checked;
        }
      }
      else
      {
         // this would uncheck it anytime the others are changed
         cbAll.Checked = CheckState.Unchecked;
      }
    }

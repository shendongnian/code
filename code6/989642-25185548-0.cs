    if(txtBox.Text.Trim().Length == 3 || txtBox.Text.Trim().Length == 4 )
    {
      if (fanRPM >= classRPM)
      {
        MessageBox.Show("hi");
      }
      else if (fanRPM < classRPM)
      {
        MessageBox.Show("Hide");
      }
    }

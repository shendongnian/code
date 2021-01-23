    private void CheckedOptionChanged(object sender, EventArgs e)
    {
      if (sender == cbAll)
      {
        foreach (var cb in checkBoxes)
        {
          cb.Checked = cbAll.Checked;
        }
      }
      else if (!((Checkbox)sender).Checked)
      {
        cbAll.Checked = false;
      }
    }

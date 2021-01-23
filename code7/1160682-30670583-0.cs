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
         cbAll.Checked = !checkBoxes.Any(cb => cb.Checked);
      }
    }

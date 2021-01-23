    private int prev_index = -1;
    private void CowTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
          DialogResult Result = MessageBox.Show
          ("somthing",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          if (Result == DialogResult.No)
          {
                CowTypeSelect.SelectedIndex = prev_index;
                return;
          }    
          else if (Result == DialogResult.Yes)
          {
                NotGrazingradioButton.Checked = true;
    
                if (CowTypeSelect.SelectedIndex == 0)
                {
                    CowTypeDefaults.LactatingCow(this);
                    CowTypeVarlbl.Text = "گاو شیری";
                }
    
                else if (CowTypeSelect.SelectedIndex == 1)
                {
                    CowTypeDefaults.DryCow(this);
                    CowTypeVarlbl.Text = "گاو خشک";
                }
         }
         prev_index = CowTypeSelect.SelectedIndex;
    }

      if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonnumberenter = true;
                        string abc = "Please enter numbers only.";
                        DialogResult result1 = MessageBox.Show(abc.ToString(), "Validate numbers", MessageBoxButtons.OK);
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonnumberenter = true;
                string abc = "Please enter numbers only.";
                DialogResult result1 = MessageBox.Show(abc.ToString(), "Validate numbers", MessageBoxButtons.OK);
    
            }

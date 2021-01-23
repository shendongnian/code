    bool FirstRun = true;
    private void CowTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FirstRun == true)
        {
            // Codes here execute at the first time only.
            NotGrazingradioButton.Checked = true;
            if (CowTypeSelect.SelectedIndex == 0)
            {
                CowTypeDefaults.LactatingCow(this);
                CowTypeVarlbl.Text = "گاو شیری";
            }
            FirstRun = false;
            return;
        }
        //Codes below execute except the first time.
        if (MessageBox.Show("آیا مطمئن هستید؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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
            else if (CowTypeSelect.SelectedIndex == 2)
            {
                CowTypeDefaults.ReplacementHeifer(this);
                CowTypeVarlbl.Text = "تلیسه جایگزین";
            }
            else
            {
                CowTypeDefaults.YoungCalf(this);
                CowTypeVarlbl.Text = "گوساله";
            }
        }

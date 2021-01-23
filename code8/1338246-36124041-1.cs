    private void CowTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CowTypeSelect.SelectedIndex == 0)
            {
                CowTypeDefaults.LactatingCow(this);
            }
        }

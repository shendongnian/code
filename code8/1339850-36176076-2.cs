        private void CB_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Company.SelectedItem.ToString() != "Select a company" & CB_Company.SelectedItem.ToString() != "")
            {
                CB_Company.BackColor = Color.White;
                CB_Company.Enabled = false;
    
                RB_Option1.Enabled = true;
                RB_Option2.Enabled = true;
            }
        }

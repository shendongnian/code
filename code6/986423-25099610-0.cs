        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = true;
            
            if (cboTo.SelectedItem != null)
            {
                if (cboFrom.SelectedItem.ToString() == cboTo.SelectedItem.ToString())
                {
                    btnCalculate.Enabled = false;
                }
            }
        }
        private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = true;
            
            if (cboFrom.SelectedItem != null)
            {
                if (cboFrom.SelectedItem.ToString() == cboTo.SelectedItem.ToString())
                {
                    btnCalculate.Enabled = false;
                }
            }
        }

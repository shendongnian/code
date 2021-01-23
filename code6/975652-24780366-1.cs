    public delegate void ApplyDelegate();
    private void btnApply_Click(object sender, EventArgs e)
    {
       btnApply.BeginInvoke(new ApplyDelegate(ApplyAsync));
    }
    private void ApplyAsync()
    {
        bool current = false;
        if (cmbEmergencyLandingMode.SelectedIndex > 0)
        {
            if (m_WantedData != false)
            {
                DialogResult dr = MessageBox.Show(
                    this,
                    "Are you sure you want to enable Emergency Landing mode?",
                    "Warning!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                //i never get to this point
                current = (dr == DialogResult.Yes);
            }
        }
        if (m_WantedData == current)
        {
            //do something
        }
        else if (m_WantedData != null)
        { 
            //do something else
        }
    }

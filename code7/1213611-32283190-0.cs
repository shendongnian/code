    private void btnGetStation_Click(object sender, EventArgs e)
    {
         Program.form.updateSMOStatus = new Terminal.UpdateSMOStatus(updateSMOStatus);
         Program.form.showConnectionStatus();
                
    }
    
    public void updateSMOStatus(string line, string group, string stationType)
    {
          txtLineName.Text = line;
          txtGroupName.Text = group;
          txtStationType.Text = stationType;
    }

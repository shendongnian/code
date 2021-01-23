    private void DisplayEntries()
    {
        UpdateUIDelegate myDel = new UpdateUIDelegate(this.DisplayEntries);
    
        if (this.InvokeRequired)
        {
            this.BeginInvoke(myDel);
            return;  // ** change here
        }
    
        // fills some data into labels on the GUI
    }

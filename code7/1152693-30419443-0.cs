    private void button1_Click(object sender, System.EventArgs e)
    {
        SecurityIdentifier mySID = GetComputerSid();
        Messagebox.Show(mySID.ToString());
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
        Settings.Default["LastVisitedCustomer"] = lastVisitedCustomers;
        Settings.Default.Save();
    }

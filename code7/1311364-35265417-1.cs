    private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Confirm with user if they want to log out:
        var result = MessageBox.Show(
            "Are you sure you want to log out?", "Confirm Log Out",
            MessageBoxButtons.YesNo);
        if (result == System.Windows.Forms.DialogResult.Yes)
        {
            // Closing the form executes log-out:
            this.Close();
        }
    }

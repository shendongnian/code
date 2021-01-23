    // restart the application once user click on Logout Menu Item
    private void eToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //Double check if user wants to exit
        var result = MessageBox.Show("Are you sure you want to exit?", "Message",
        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
        {
            Application.Restart();
        }
    }

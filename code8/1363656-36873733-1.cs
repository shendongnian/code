    private void xButton3_Click(object sender, EventArgs e)
    {
    	DialogResult dialog = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    	if (dialog == DialogResult.Yes)
    	{
    		Application.Exit();
    	}
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult dr = MessageBox.Show("Are you sure want to close?", "Close Program", MessageBoxButtons.OKCancel);
        if (dr != DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }

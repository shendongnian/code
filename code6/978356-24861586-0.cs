    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Do You Want To Save Your Data", "CodeJuggler", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            SaveMyFile();
        }
    }

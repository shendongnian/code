    private void pdfViewer1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.P) //detect key ctrl+p
        {
            e.SuppressKeyPress = true; //<= Set it to true.
            MessageBox.Show("This Document is Protected !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }        
    }

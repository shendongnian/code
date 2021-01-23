    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Show testDialog as a modal dialog and determine if DialogResult = OK.
        if (form2.ShowDialog(this) == DialogResult.OK)
        {
            // Read the contents of testDialog's TextBox.
            this.txtResult.Text = form2.TextBox1.Text;
        }
    }

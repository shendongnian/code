    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to close the form?",
                                        "Close", MessageBoxButtons.YesNoCancel);
        if (result != System.Windows.Forms.DialogResult.Yes)
            e.Cancel = true;
    }

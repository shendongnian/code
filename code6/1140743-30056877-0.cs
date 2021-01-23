    private void uxMouseCopyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (!uxMouseCopyCheckBox.Checked)
        {
            MessageBox.Show("Test");
            uxMouseCopyCheckBox.Checked = false;
        }
    }

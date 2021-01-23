    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox) sender;
        if (cb.Checked)
        {
            MessageBox.Show("Test"); 
        }
    }

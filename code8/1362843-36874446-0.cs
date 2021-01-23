    private void checkbox1_CheckedChanged(object sender, EventArgs e)
    {
        if(var1 == "YES")
        {
            if (checkbox1.Checked)
            {
                numbox.Enabled = true;
                combobox1.Enabled = true;
            }
            else
            {
                numbox.Enabled = false;
                combobox1.Enabled = false;
            }
        }
        else if (checkbox1.Checked)
        {
            MessageBox.Show("Required condition is not YES");
            checkbox1.Checked = false;
        }
    }

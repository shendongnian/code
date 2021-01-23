    void b_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton b = sender as RadioButton;
    
        if (b.Checked == true)
        {
            b.Text = b.Name + " (CHECKED)";
        }
        else
        {
            b.Text = b.Name + " (NOT CHECKED)";
        }
    }

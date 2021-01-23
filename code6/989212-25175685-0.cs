    private void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        var radiobutton = (RadioButton)sender;
        if (radiobutton.Checked)
        {
            // some logic here
            label.Text = radiobutton.Text;
        }
    }

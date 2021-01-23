    private void timer3_Tick(object sender, EventArgs e)
    {
        if (ComboBox3.Items.Count > 1)
        {
            SendKeys.Send(comboBox3.Text);
        }
        //rest of code
    }

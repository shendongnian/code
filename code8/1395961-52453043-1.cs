    private void comboBox1_KeyUp(object sender, KeyPressEventArgs e)
    {
        //if Enter (return) key is pressed
        if (e.KeyChar == (char)13)
        {
            //don't add text if it's empty
            if (comboBox1.Text != "")
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    //exit event if text already exists
                    if (comboBox1.Text == comboBox1.Items[i].ToString())
                    {
                        return;
                    }
                }
                //add item to comboBox1
                comboBox1.Items.Add(comboBox1.Text);
            }
        }
    }

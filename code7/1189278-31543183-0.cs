    private void InitComboBox()
    {
      comboBox1.Items.Add("Command1");
      comboBox1.Items.Add("Command2");
      comboBox1.Items.Add("Command3");
      comboBox1.Items.Add("Command4");
      comboBox1.Items.Add("Command5");
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (comboBox1.SelectedItem.ToString().Equals("Command1"))
      {
        //Excute Command here
      }
      //...
    }

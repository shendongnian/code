	private void button1_Click(object sender, EventArgs e)
	{
		decimal itemPrice;
        //if the textbox is empty or cannot be parsed to a decimal
        //then we cast the combobox1.SelectedItem to a Drink type
        //place that value into the textbox. If, however, it can be
        //parsed to a decimal then we grab that value and add the
        //price of our newly selected combobox item to the price
        //that is currently in the textbox.
		if(decimal.TryParse(textBox1.Text, out itemPrice))
		{
			textBox1.Text = (itemPrice + ((Drink)(comboBox1.SelectedItem)).Price).ToString();
		}
		else
		{
			textBox1.Text = (((Drink)(comboBox1.SelectedItem)).Price).ToString();
		}
	}

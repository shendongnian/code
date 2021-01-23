    ComboBox comboBox = sender as ComboBox;
    if (comboBox != null && comboBox.SelectedItem != null)
    {
        //For simplicity sake, I left error handling
        //You'll want to use double.TryParse to handle any unexpected text in the subtotal textbox.
        double price = Convert.ToDouble(subTotalTb.Text) + priceMapping[comboBox.SelectedItem.ToString()];
        subTotalTb.Text = price.ToString();
    }

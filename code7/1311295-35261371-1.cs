    ComboBox comboBox = sender as ComboBox;
    if (comboBox != null && comboBox.SelectedItem != null)
    {
        double price = Convert.ToDouble(subTotalTb.Text) + priceMapping[comboBox.SelectedItem.ToString()];
        subTotalTb.Text = price.ToString("C");
    }

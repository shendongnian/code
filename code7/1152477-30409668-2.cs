    string lessTrade = (string.IsNullOrEmpty(lessTradeInTextBox.Text)) ? "0" : textBox1.Text;
    string vehiclePrice = (string.IsNullOrEmpty(vehiclePriceTextBox.Text)) ? "0" : textBox1.Text;
    decimal lessTradeD, vehiclePriceD;
    if (decimal.TryParse(lessTrade, out lessTradeD) & decimal.TryParse(vehiclePrice, out vehiclePriceD))
    {
        if (lessTradeD > vehiclePriceD)
        {
            MessageBox.Show("The trade-in price cannot be greater than the purchase price");
            Keyboard.Focus(lessTradeInTextBox);
        }
        else
        {
            // calculations go here
        }
    }
    else
    {
        //wrong input, do your exceptin handling.
    }

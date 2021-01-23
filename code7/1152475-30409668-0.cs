            try
            {
                string lessTrade = (string.IsNullOrEmpty(lessTradeInTextBox.Text)) ? "0" : textBox1.Text;
                string vehiclePrice = (string.IsNullOrEmpty(vehiclePriceTextBox.Text)) ? "0" : textBox1.Text;
                if (decimal.Parse(lessTrade) > decimal.Parse(vehiclePrice))
                {
                    MessageBox.Show("The trade-in price cannot be greater than the purchase price");
                    Keyboard.Focus(lessTradeInTextBox);
                }
                else
                {
                    // calculations go here
                }
            }
            catch (Exception)
            {
                //do your exception handling.
            }

        double itemTotal = 0.0;
    
    private void checkOutButton_Click(object sender, EventArgs e)
    {
    
        double drinkPrice = 0.0;
        
        double smDrink = 3.00;
        double mdDrink = 3.50;
        double lgDrink = 4.00;
        int intQuantity;
        string strMessage;
    
        if (smallRB.Checked)
        {
            drinkPrice = smDrink;
        }
        else if (mediumRB.Checked)
        {
            drinkPrice = mdDrink;
        }
        else if (largeRB.Checked)
        {
            drinkPrice = lgDrink;
        }
        else
        {
            MessageBox.Show("Please make a size selection", "Selection Required",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        double additive = 2.50;
    
        if (vpCB.Checked)
        {
            drinkPrice = drinkPrice + additive;
    
            if (ebCB.Checked)
            {
                drinkPrice = drinkPrice + additive;
                if (cdCB.Checked)
                {
                    drinkPrice = drinkPrice + additive;
                }
            }
        }
    
    
    
        //Calculate extended price and add to order total
        if (quantityTextBox.Text != "")       //Not blank
        {
            try
            {
                intQuantity = int.Parse(quantityTextBox.Text);
                itemTotal = drinkPrice * intQuantity;
                totalDueTextBox.Text = itemTotal.ToString("C");
            }
            catch (FormatException err)
            {
                strMessage = "Nonnumeric data entered for quantity.";
                MessageBox.Show(strMessage, "Data Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantityTextBox.Focus();
            }
            catch
            {
                strMessage = "Calculation error.";
                MessageBox.Show(strMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else           //Missing data
        {
            strMessage = "Enter the quantity.";
            MessageBox.Show(strMessage, "Data entry error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            quantityTextBox.Focus();
        }//end if
    }

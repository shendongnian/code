    decimal subtotal;
    if (Decimal.TryParse(txtSubtotal.Text))
    {
        if (subtotal <= 0)
           MessageBox.Show("Subtotal must be greater than 0");
        else if (subtotal >= 10000)
            MessageBox.Show("Subtotal must be less than 10000");
        else
        { 
         // Process your code here
        }
    }
    else
    {
        MessageBox.Show("Invalid Input! Subtotal Expecting a Decimal value");
    }

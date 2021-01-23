    decimal total;
    decimal minimum;
    decimal maximum;
    if(!decimal.TryParse(txtTotal.Text, out total))
    {
        MessageBox.Show("Not a valid total value");
        return;
    }
    // Not really needed to check if the conversion works because 
    // the default value assigned to the out variable will be zero
    decimal.TryParse(txtSmallestInvoice.Text, out minimum);
    decimal.TryParse(txtLargestInvoice.Text, out maximum);
    if(total < minimum)
       txtSmallestInvoice.Text = txtTotal.Text;
    if(total > maximum)
       txtLargestInvoice.Text = txtTotal.Text;

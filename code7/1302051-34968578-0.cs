    if (txtTotal.Text != "" && txtSmallestInvoice.Text != "" && txtLargestInvoice.Text != "")
    {
      if (Convert.ToDecimal(txtTotal.Text) < Convert.ToDecimal(txtSmallestInvoice.Text))
            {
                txtSmallestInvoice.Text = txtTotal.Text;
            }
    
    if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(txtLargestInvoice.Text))
            {
                txtLargestInvoice.Text = txtTotal.Text;
            }
    }

    private void txtQty_TextChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }
    private void txtRate_TextChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }
    private void UpdatePrice()
    {
          int r = 0, q = 0;
          int.TryParse(txtRate.Text, out rate);
          int.TryParse(txtQty.Text, out qty);
          txtPrice.Text = (r*q).toString()
    }
 

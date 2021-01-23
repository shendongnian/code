    private void txtQty_TextChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }
    private void txtRate_TextChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }
    
    //code from user2893289 answer
    private void UpdatePrice()
    {
          int r = 0, q = 0;
          int.TryParse(txtRate.Text, out r);
          int.TryParse(txtQty.Text, out q);
          txtPrice.Text = (r*q).toString()
    }
 

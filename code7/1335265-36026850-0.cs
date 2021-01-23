        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            double price, qty, total;
            double.TryParse(txtPrice.Text, out price);
            if (!double.TryParse(txtQty.Text, out qty))
            {
                txtTotal.Text = "0.00";
                txtQty.BackColor = Color.Red; //indicates wrong input
            }
            else
            {               
                total = price * qty;
                txtTotal.Text = total.ToString();
            }
        }

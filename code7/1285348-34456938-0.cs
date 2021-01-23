        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
              int rate = 0;
              int qty = 0;
    
              Int32.TryParse(txtRate.Text, out rate);
              Int32.TryParse(txtQty.Text, out qty);
              
              int total = rate * qty
              
              // Set the new textBox value
              // txtTotal should be your textbox value (what you have called it)
              txtTotal.Text = total.toString()
        }

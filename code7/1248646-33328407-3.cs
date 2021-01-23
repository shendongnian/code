           private void txtSubtotal_KeyDown(object sender, KeyEventArgs e)
           {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtSubtotal.Text.Length > 0)
                {
                    bool sd = iCnF.IsNumeric(txtSubtotal.Text);
                    if (sd == false)
                    {
                       MessageBox.Show("Subtotal must be a numeric value. ", "Error Entry");
                       txtSubtotal.Clear();
                       txtSubtotal.Focus();
                    }
                    else
                    {
                        decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
                        if (subtotal <= 0)
                        {
                            MessageBox.Show("Subtotal must be greater than $0.00. ", "Error Entry");
                            txtSubtotal.Focus();
                       }
                       if (subtotal >= 10000)
                       {
                           MessageBox.Show("Subtotal must be less than $10000.00. ", "Error Entry");
                           txtSubtotal.Focus();
                       }
                   }
               }
               else
               {
                   MessageBox.Show("Subtotal must not be empty. ", "Error Entry");
                   txtSubtotal.Focus();
               }
           }
          }  

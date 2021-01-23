        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            double amount = 0.0d;
            try
            {
                amount = Convert.ToDouble(txtbox1.Text);
                textbox.Text = amount.ToString("C");
            }
            catch
            {
    
            }          
        }

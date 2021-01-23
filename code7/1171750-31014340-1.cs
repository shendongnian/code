        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Contains('.') && (e.KeyChar == '.')) e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if (((sender as TextBox).Text == "0") && (e.KeyChar == '0')) e.Handled = true;
            double value = 0;
            string inputValue = (sender as TextBox).Text + e.KeyChar;
            if ((sender as TextBox).Text.Length > 0)
            {
                if (double.TryParse(inputValue, out value))
                {
                    if (value > 0.9999) e.Handled = true;
                    if (((sender as TextBox).Text.Length > 4) && (value < 0.0001)) e.Handled = true;
                }
            }
            else if (e.KeyChar != '0')
            {
                e.Handled = true;
            }
        }

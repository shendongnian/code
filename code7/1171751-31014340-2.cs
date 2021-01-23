        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only one dot is possible
            if ((sender as TextBox).Text.Contains('.') && (e.KeyChar == '.')) e.Handled = true;
            //Only numeric keys are acceptable
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            //Only one zero in front is acceptable, next has to be dot
            if (((sender as TextBox).Text == "0") && (e.KeyChar == '0')) e.Handled = true;
            double value = 0;
            string inputValue = (sender as TextBox).Text + e.KeyChar;
            if ((sender as TextBox).Text.Length > 0)
            {
                //Just in case parse input text into double
                if (double.TryParse(inputValue, out value))
                {
                    //Check if value is between 0.0001 and 0.9999
                    if (value > 0.9999) e.Handled = true;
                    if (((sender as TextBox).Text.Length > 4) && (value < 0.0001)) e.Handled = true;
                }
            }
            else if (e.KeyChar != '0')
            {
                e.Handled = true;
            }
        }

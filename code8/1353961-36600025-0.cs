    private void btnsubmit_Click(object sender, RoutedEventArgs e)
    {
        {
            double monthlypayment = 0;
            //Tryparse for principal amount with error Red texbox
            if (String.IsNullOrEmpty(txtprincipal.Text) || !double.TryParse(txtprincipal.Text, out principal))
            {
                txtprincipal.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            else
                txtprincipal.BorderBrush = new SolidColorBrush(Colors.Black);
            //Validate radio button
            if (rad10years.IsChecked.Value)
            {
                years = 10;
                //return;
            }
            else if (rad20years.IsChecked.Value)
            {
                years = 20;
                //return;
            }
            else if (rad30years.IsChecked.Value)
            {
                years = 30;
                //return;
            }
            else if (radother.IsChecked == true)
            {
                if (!double.TryParse(txtother.Text, out years))
                {
                    MessageBox.Show("Not a Valid year.");
                    return;
                }
                //return;
            }
            else
            {
                MessageBox.Show("Please select number of years.");
                stkrdobtns.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            //monthlypayment = ((principal * rate) / 1200) / Math.Pow(1 - (1.0 + rate / 1200), (-12.0 * years));
            var r = rate / 1200.0;
            var n = years * 12.0;
            monthlypayment = principal * ((r * Math.Pow((1 + r), n)) / (Math.Pow(1 + r, n) - 1));
            string MonthPay = string.Format("The amount of the monthly payment is: {0:c}", monthlypayment);
            MessageBox.Show(MonthPay);
        }
    }

    private void button_Click(object sender, RoutedEventArgs e)
            {
                double balance = double.Parse(Balance.Text);
                double withdraw = double.Parse(Withdraw.Text);
                double overdraft = double.Parse(Overdraft.Text);
    
                if(balance < withdraw)
                {
                    balance -= (overdraft + withdraw);
                    Balance.Text = balance.ToString();
    
                }
                else if(balance > withdraw)
                {
                    balance -= withdraw;
                    Balance.Text = balance.ToString();
                }
            }

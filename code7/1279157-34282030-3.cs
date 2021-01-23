    private void depositButton_Click(object sender, EventArgs e)
    {
        decimal amount;
        if (decimal.TryParse(depositTextBox.Text, out amount))
        {
            account.Deposit(amount);
            account.Balance += amount;
            depositTextBox.Clear();
            balanceLabel.Text = account.Balance.ToString("c"); // This line added
        }
        else
        {
            MessageBox.Show("Pls enter valid amount.");
        }
    }

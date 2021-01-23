    private BankAccount account;
    private void accountNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (accountNumComboBox.SelectedIndex == 0)
        {
               account = (BankAccount) savings1;
        }
        updateUi();
    }
    private void updateUi() {
        ownerIdLabel.Text = "0001";
        balanceLabel.Text = account.Balance.ToString("c");
        interestLabel.Text = (string.Format("{0}%", account.Interest));
        interestRLabel.Text = "Interest Rate:";
    }
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

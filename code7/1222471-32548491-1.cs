            List<int> coinList = new List<int>();
            private void ClickToAddMoreCoins2(object sender, RoutedEventArgs e)
            {
                int sum = 0;
    
        //Hides InputBox and takes input text from user.
        //InputTextBox.Visibility = System.Windows.Visibility.Collapsed;
        
        // Ensuring that input from user is a integer number
        String input = InputTextBox.Text;
        int result = 0;
        if (int.TryParse(input, out result) && result > 0)
        {
            //Adding number of coins to CoinListBox
            coinList.Add(result);
        }
        else
        {
            MessageBox.Show("Please enter a valid number of coins");
        }
        sum = coinList.Sum();
        if (sum > 30)
        {
            sum -= result;
            //Removing last coin in case number of coins exceeds 30
            coinList.RemoveAt(coinList.Count - 1);
            MessageBoxResult answer = MessageBox.Show("You cannot enter more than 30 coins. Do you want to end?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    
        tbSum.Text = "Sum = " + sum.ToString();
    
        // Resets InputBox.
        InputTextBox.Text = String.Empty;
    
        InputTextBox.Focus();
            }

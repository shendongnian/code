        ...
        CoinListBox.Visibility = System.Windows.Visibility.Collapsed;
        ...
        sum = CoinListBox.Items.Cast<object>().Sum(x => Convert.ToInt32(x));
                    if (sum > 30)
                    {
                        sum -= result; // removing excess coin
        
                        //Removing last coin in case number of coins exceeds 30
                        CoinListBox.Items.RemoveAt(CoinListBox.Items.Count - 1);
                        MessageBoxResult answer = MessageBox.Show("You cannot enter more than 30 coins. Do you want to end?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (answer == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }

         int sum = 0;
        private void ClickToAddMoreCoins(object sender, RoutedEventArgs e)
        {
            if (sum+(int) (InputTextBox.Text) > 30)
            {
                //Removing last coin in case number of coins exceeds 30
                CoinListBox.Items.RemoveAt(CoinListBox.Items.Count - 1);
                MessageBoxResult answer = MessageBox.Show("You cannot enter more than 30 coins. Do you want to end?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (answer == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }     
            //Hides InputBox and takes input text from user.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;
            // Ensuring that input from user is a integer number
            string number = InputTextBox.Text;
            int num;
            if(int.TryParse(number,out num))
            {
                sum += num;
              try { CoinListBox.Items.RemoveAt(0); 
                  } catch
           {}
        CoinListBox.Items.Add(sum);
            }
            InputTextBox.Text = string.Empty;
         
        }

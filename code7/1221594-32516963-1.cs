    private void YesButton_Click(object sender, RoutedEventArgs e)
        {
          int sum = 0;
          int i = 0;
          // YesButton Clicked! Let's hide our InputBox and handle the input text.
          InputBox.Visibility = System.Windows.Visibility.Collapsed;
        // Do something with the Input
        String input = InputTextBox.Text;
        int result = 0;
        if (int.TryParse(input, out result))
        {
            MyListBox.Items.Add(result); // Add Input to our ListBox.
        }
        else 
        {
           sum = MyListBox.Items.Cast<int>().Sum(x => Convert.ToInt32(x));
           MessageBox.Show("Sum is: " +sum);
        }
        // Clear InputBox.
        InputTextBox.Text = String.Empty;
    }

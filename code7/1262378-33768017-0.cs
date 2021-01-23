    private async void two_Click(object sender, RoutedEventArgs e)
    {
      var input = Convert.ToInt64(txtprime.Text);
      answer = await Task.Run(() => FindPrimeNumber(input));
      MessageBox.Show(answer.ToString());
    }

      private void textBox_LostFocus(object sender, RoutedEventArgs e)
       {
          double amount = 0.0d;
          if (Double.TryParse(textBox.Text, NumberStyles.Currency, null, out amount))
        {
            textBox.Text = amount.ToString("C", new System.Globalization.CultureInfo("en-GB"));
        }
    }

     int i = 0;
     private void Button_Tapped(object sender, TappedRoutedEventArgs e)
     {
        TestTextBox.Text = TestTextBox.Text + " newtest " + i++ + Environment.NewLine;
        TestTextBox.SelectionStart = TestTextBox.Text.Length;
     }

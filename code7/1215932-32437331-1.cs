        int i = 0;
        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TestTextBox.Text = TestTextBox.Text + " newtest " + i++;
            TestTextBox.SelectionStart = TestTextBox.Text.Length;
            sv.ChangeView(null, sv.ScrollableHeight, null);
        }
        ScrollViewer sv; 
        private void ContentElement_Loaded(object sender, RoutedEventArgs e)
        {
            sv = sender as ScrollViewer;
        }

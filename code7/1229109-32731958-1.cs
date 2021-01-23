	private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tab1.SelectedIndex + 1 < tab1.Items.Count)
            {
                tab1.SelectedIndex = tab1.SelectedIndex + 1;
            }
            else
            {
                tab1.SelectedIndex = 0;
            }
        }

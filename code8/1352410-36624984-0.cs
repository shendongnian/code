    private void Home_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Tag.ToString())
                {
                    case "Home":
                        this.MyFrame.Navigate(typeof(Views.Home_Page));
                        break;
                    case "Settings":
                        this.MyFrame.Navigate(typeof(Views.Settings_Page));
                        break;
                }
                Header.Text = button.Tag.ToString();
            }
        }

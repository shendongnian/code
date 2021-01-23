     private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                for (var i = 0; i <= 100; i++)
                {
                    ((Button) sender).Content = i.ToString();
                    await Task.Delay(100);
                }
            }

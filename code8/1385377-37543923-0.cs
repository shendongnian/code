     void SelectAllText(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Released)
            {
                var textBox = sender as System.Windows.Controls.TextBox;
                if (textBox != null)
                    if (!textBox.IsReadOnly)
                        textBox.SelectAll();
            }
        }

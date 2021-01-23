     private void OK_Button_Click(object sender, RoutedEventArgs e)
            {
                BindingExpression binding = tb1.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
            {
                TextBox tb = (TextBox)sender;
                int result;
                if (!int.TryParse(tb.Text, out result))
                    tb.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            } 

      private void txt_Time_LostFocus(object sender, RoutedEventArgs e)
            {
                var txtBox = sender as TextBox;
                Binding myBinding = BindingOperations.GetBinding(txt_Time, TextBox.TextProperty);
                var elementName = myBinding.ElementName;
            }

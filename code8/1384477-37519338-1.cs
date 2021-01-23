     private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBox=new TextBox();            
            mygrid.RowDefinitions.Add(new RowDefinition());
            textBox.Name = "textBox" + mygrid.RowDefinitions.Count;
            textBox.SetValue(Grid.RowProperty, mygrid.RowDefinitions.Count);
            mygrid.Children.Add(textBox);
        }       
        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var focusedElement = Keyboard.FocusedElement;
            if (focusedElement is TextBox)
            {
                mygrid.Children.Remove(focusedElement as UIElement);
            }
        }  

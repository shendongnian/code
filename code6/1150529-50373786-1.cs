      private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel stack = sender as StackPanel;
            Button button = stack.Children.OfType<Button>().FirstOrDefault();
            button.Content = "Change Content";
        }

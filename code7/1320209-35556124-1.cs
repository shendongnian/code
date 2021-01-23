    private void Button_Click(object sender, RoutedEventArgs e)
        {
             var button = sender as Button;
             List<object> list = (button.Tag as ItemsControl).ItemsSource.OfType<TodoItem>().ToList<object>();
            list.Remove(button.DataContext);
            (button.Tag as ItemsControl).ItemsSource = list;
        }

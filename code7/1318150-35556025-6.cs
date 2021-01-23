    private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            items.Remove(button.DataContext as TodoItem);
            icTodoList.ItemsSource = null;
            icTodoList.ItemsSource = items;            
        }

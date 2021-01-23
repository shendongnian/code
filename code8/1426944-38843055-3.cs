     private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var list = button.DataContext as ObservableCollection<string>;
            list.Add(this.txtbox.Text.ToString());
        }

    public partial class MainWindow : Window
    {
        int Numberic = 0;
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var item = new Item();
            item.Id = ++Numberic;
            MyItemsControl.Items.Add(item);
        }
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)sender;
            var item = SelectedButton.DataContext;
            MyItemsControl.Items.Remove(item);
        }
    }

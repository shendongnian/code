    public partial class MainWindow : Window
    {
        int Numberic = 0;
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            MyItemsControl.Items.Add(new Item() { Id = ++Numberic });
        }
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)sender;
            var item = SelectedButton.DataContext;
            MyItemsControl.Items.Remove(item);
        }
    }

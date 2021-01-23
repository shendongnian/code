     private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MyViewModel).MyItems.Remove(MyDataGrid.SelectedItems[2] as MyObject);
            MyDataGrid.Items.Refresh();
            MyDataGrid.Focus();
        }

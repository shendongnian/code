    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DataGridTextColumn dgTextColumn = new DataGridTextColumn();
        dgTextColumn.Header = "ID";
        dgTextColumn.Binding = new Binding("ID");
        dataGrid1.Columns.Add(dgTextColumn);
        DataGridCheckBoxColumn dgCheckBoxColumn = new DataGridCheckBoxColumn();
        dgCheckBoxColumn.Header = "IsChecked";
        dgCheckBoxColumn.Binding = new Binding("IsChecked");
        dataGrid1.Columns.Add(dgCheckBoxColumn);
        DataGridTextColumn dgTextColumn2 = new DataGridTextColumn();
        dgTextColumn2.Header = "Name";
        dgTextColumn2.Binding = new Binding("Name");
        dataGrid1.Columns.Add(dgTextColumn2);
        dataGrid1.Items.Add(new Item() { ID = 1, Name = "Someone1", IsChecked = true });
        dataGrid1.Items.Add(new Item() { ID = 2, Name = "Someone2", IsChecked = false });
        dataGrid1.Items.Add(new Item() { ID = 3, Name = "Someone3", IsChecked = true });
        dataGrid1.Items.Add(new Item() { ID = 4, Name = "Someone4", IsChecked = false });
    }

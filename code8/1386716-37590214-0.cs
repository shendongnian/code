    private void button_Click(object sender, RoutedEventArgs e)
    {
     if (yourdatagrid.SelectedItem != null)
      {
       object item = yourdatagrid.SelectedItem;
       string record= (yourdatagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
       // your SQL Update code with selected values here
      }
    }

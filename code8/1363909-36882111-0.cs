    IEnumerable list = DataGridDetail.ItemsSource as IEnumerable;
    List<string> lstFile = new List<string>();
    
    int i = 0;
    foreach (var row in list)
    {
    bool IsChecked = (bool)((CheckBox)DataGridDetail.Columns[0].GetCellContent(row)).IsChecked;
    if (IsChecked)
    {
      MessageBox.show(i);
    --Here i want to get the index or current row from the list                   
    
    }
     ++i;
    }

    private string GetDatagrid(DataGrid grid)
    {
        var data = (ObservableCollection<ConfigViewModel>)grid.ItemsSource;
        StringBuilder dataStr = new StringBuilder();
        for (int i = 0; i < data.Count; i++)
        {
            dataStr.Append(data[i].PropertyDataboundToTextBlockText);
        }
        return dataStr.ToString();
    }

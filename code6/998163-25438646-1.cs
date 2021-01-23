    //cast to correct type
    var data = (ObservableCollection<MyClass>)grid.ItemsSource;
    StringBuilder stringStr = new StringBuilder();
    //loop through your data instead of DataGrid it self
    for (int i = 0; i < data.Count; i++)
    {
    	//get the value from correct property of your class model
    	string inputName = data[i].MyProperty;
        //or if you really have to get it from cell content :
        //TextBlock selectTextBlockInCell = grid.Columns[0].GetCellContent(data[i]) as TextBlock;
        //string inputName = selectTextBlockInCell.Text;
    	stringStr.Append(@"\pic () at (-0.5,");
    	stringStr.Append(3 - i);
    	stringStr.Append(inputName);
    	stringStr.Append(@"}");
    }
    return stringStr.ToString();

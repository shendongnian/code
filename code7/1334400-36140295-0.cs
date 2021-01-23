    private void GenerateColumnEvent(object sender, EventArgs e)
    {
        var table = sender as DataGrid;
        var context = table.DataContext 
    
        //Regular column definitions
    
        foreach(var category in context.CategoryIDList)
        {
            var binding = new Binding("CategoryWrapper")
            {
                Converter = new FindCategoryProperty(),
                    ConverterParameter = new Tuple<categoryID, string>(category, "Property1")
            };
            var column = new DataGridTextColumn
            {
                Binding = binding,
                //Other column defining things (templates, headers, etc)
            };
            table.Columns.Add(column);
    
            //More column definitions
        }
    }

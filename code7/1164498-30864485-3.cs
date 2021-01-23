    // Sample drop down list of products to show
    public ObservableCollection<string> ProductList = new ObservableCollection<string> { "Item1", "Item2", "Item3" };
    private void BuildQuotationDGColumns(List<ProductCategory> ProdCatList)
    {
        // Define a DataGridComboBoxColumn 
        DataGridComboBoxColumn prodComboColumn = new DataGridComboBoxColumn();
        // Bind this column to the first item of the DataGrid.ItemsSource (e.g. MyData[0])
        prodComboColumn.SelectedItemBinding = new Binding("[0]");
        prodComboColumn.Header = "Choose Product";
        // Set ProductList as the ItemsSource of DataGridComboBoxColumn
        Style style = new Style(typeof(ComboBox));
        style.Setters.Add(new Setter(ComboBox.ItemsSourceProperty, ProductList));
        prodComboColumn.ElementStyle = style;
        prodComboColumn.EditingElementStyle = style;
        QuotationDG.Columns.Add(prodComboColumn);
        // For each entity in ProdCatList add a text column
        int i = 1;
        foreach (ProductCategory ProdCat in ProdCatList)
        {
            // Define a DataGridTextColumn 
            DataGridTextColumn ProdCatColumn = new DataGridTextColumn();
            ProdCatColumn.Header = ProdCat.Name;
            // Bind this column to the i-th item of the DataGrid.ItemsSource (e.g. MyData[i])
            ProdCatColumn.Binding = new Binding(string.Format("[{0}]", i));
            QuotationDG.Columns.Add(ProdCatColumn);
            i++;
        }
        insertDummyRow();
    }

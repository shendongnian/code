    private void Button_Click(object sender, RoutedEventArgs e)
    {
        CultureInfo provider = new CultureInfo("en-US");
        Object[] myrow = new Object[QuotationDG.Columns.Count];
        int i = 0;
        foreach (DataGridColumn column in QuotationDG.Columns)
        {
            if (column is DataGridComboBoxColumn)
                myrow[i] = Convert.ChangeType(ProductList[0], typeof(object), provider);
            else
                myrow[i] = Convert.ChangeType(column.Header.ToString(), typeof(object), provider);
            i++;
        }
        MyData.Add(myrow);
        QuotationDG.ItemsSource = MyData;
    }

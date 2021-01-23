    private void Add_Click(object sender, RoutedEventArgs e)
    {
        //Select my supplier from my Supplier's combobox
        var supplier = ComboBoxTest.SelectedItem as string;
        //Create the Supplier column and bind it to my 'ViewQuoteItemList' class +
        //I'm binding it to the unique supplier selected from my combobox
        DataGridTextColumn columnFeedbackSupplier = new DataGridTextColumn();
        columnFeedbackSupplier.Binding = new Binding("Suppliers[" + supplier + "]");
        columnFeedbackSupplier.Binding.FallbackValue = "Binding failed";
        columnFeedbackSupplier.CanUserReorder = true;
        columnFeedbackSupplier.CanUserResize = true;
        columnFeedbackSupplier.IsReadOnly = false;
        columnFeedbackSupplier.Header = ComboBoxTest.SelectedItem as string;
        foreach (var item in DataGridTest.ItemsSource as List<ViewQuoteItemList>)
            if (!item.Suppliers.ContainsKey(supplier))
                item.Suppliers.Add(supplier, string.Empty);
        DataGridTest.Columns.Add(columnFeedbackSupplier);
    }

    <DataGridTemplateColumn >
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate >
                                    <ComboBox Loaded="LoadItemsSource"/>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
      private void LoadItemsSource(object sender, RoutedEventArgs e)
            {
    
                ComboBox comboBox = sender as ComboBox;
    
               
                comboBox.ItemsSource=model.sourceDropDown;
    
            }

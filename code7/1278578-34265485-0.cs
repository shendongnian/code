    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
          <TextBlock Text="{Binding Area, Mode=TwoWay, UpdateSourceTrigger=LostFocus}"  Loaded="TextBlock_Loaded"/>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
 
    private void TextBlock_Loaded(object sender, RoutedEventArgs e)
    {
        TextBlock tb = ((TextBlock)sender);
        
        // do anything with textblock    
        if (tb.Text == 10)
        {
            tb.Background = Brushes.Plum;
        }
    }

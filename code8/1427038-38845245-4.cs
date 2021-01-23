    if (!database.IsMaster)
    {
        DataGridTextColumn dgtc = new DataGridTextColumn();
        dgtc.Header = database.DisplayName;
        dgtc.Binding = new Binding("LocationValues[" + counter + "]");
        
        Setter setter = new Setter();
        setter.Property = Control.BackgroundProperty;            
        setter.Value = Brushes.Red;
        Trigger trigger = new Trigger();
        trigger.Property = DataGridCell.ContentProperty;
        trigger.Value = true;
        trigger.Setters.Add(setter);
        dataGrid.Columns.Add(dgtc);
        counter++;
    }

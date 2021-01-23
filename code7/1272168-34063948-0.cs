    Style headerStyle = new Style(typeof(DataGridColumnHeader));
    headerStyle.Setters.Add(
         new Setter(DataGridColumnHeader.BackgroundProperty, Brushes.AliceBlue));
    lb.Columns.Add(new DataGridTextColumn()
    {
         Header = eName,
         HeaderStyle = headerStyle
     });

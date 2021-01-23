    DataGrid tabelle = new DataGrid();
    tabelle.ItemsSource = dt.DefaultView;
    tabelle.RowHeight = 50;
    // cell style with centered text
    var cellStyle = new Style
                    {
                        TargetType = typeof (TextBlock),
                        Setters =
                        {
                            new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center),
                            new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center),
                        }
                    };
    // assign new style for text columns when they are created
    tabelle.AutoGeneratingColumn += (sender, e) =>
    {
        var c = e.Column as DataGridTextColumn;
        if (c != null)
            c.ElementStyle = cellStyle;
    };

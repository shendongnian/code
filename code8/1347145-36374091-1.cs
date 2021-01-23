    private void Button_2x2(object sender, RoutedEventArgs e)
    {
        A.SetValue(Grid.RowProperty,0);
        A.SetValue(Grid.RowSpanProperty,3);
        A.SetValue(Grid.ColumnProperty,0);
        A.SetValue(Grid.ColumnSpanProperty,2);
        B.SetValue(Grid.RowProperty, 0);
        B.SetValue(Grid.RowSpanProperty, 3);
        B.SetValue(Grid.ColumnProperty, 2);
        B.SetValue(Grid.ColumnSpanProperty, 2);
        C.SetValue(Grid.RowProperty, 3);
        C.SetValue(Grid.RowSpanProperty, 3);
        C.SetValue(Grid.ColumnProperty, 0);
        C.SetValue(Grid.ColumnSpanProperty, 2);
        D.SetValue(Grid.RowProperty, 3);
        D.SetValue(Grid.RowSpanProperty, 3);
        D.SetValue(Grid.ColumnProperty, 2);
        D.SetValue(Grid.ColumnSpanProperty, 2);
    }
<!---->
    private void Button_1x3(object sender, RoutedEventArgs e)
    {
        A.SetValue(Grid.RowProperty, 0);
        A.SetValue(Grid.RowSpanProperty, 6);
        A.SetValue(Grid.ColumnProperty, 0);
        A.SetValue(Grid.ColumnSpanProperty, 3);
        B.SetValue(Grid.RowProperty, 0);
        B.SetValue(Grid.RowSpanProperty, 2);
        B.SetValue(Grid.ColumnProperty, 3);
        B.SetValue(Grid.ColumnSpanProperty, 1);
        C.SetValue(Grid.RowProperty, 2);
        C.SetValue(Grid.RowSpanProperty, 2);
        C.SetValue(Grid.ColumnProperty, 3);
        C.SetValue(Grid.ColumnSpanProperty, 1);
        D.SetValue(Grid.RowProperty, 4);
        D.SetValue(Grid.RowSpanProperty, 2);
        D.SetValue(Grid.ColumnProperty, 3);
        D.SetValue(Grid.ColumnSpanProperty, 1);
    }

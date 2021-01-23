    DataGridTextColumn valColumn = new DataGridTextColumn();
    Binding valBinding = new Binding( "SomeVal" );
    valBinding.Converter = new DecimalConverter();
    valColumn.Binding = valBinding;
    dgTest.Columns.Add( valColumn );
    dgTest.ItemsSource = Objects;

    DataGrid dg; // Your DataGrid
    var column = (DataGridTextColumn)dg.CurrentCell.Column; // Selected cell's column
    var format = column.Binding.StringFormat;
    var bind = new Binding(column.Header.ToString()); // Bind to the same column of underlying Source
    bind.Mode = BindingMode.OneWay;
    bind.StringFormat = "F2"; // Two decimal places, add your code here
    column.Binding = bind;// Set new binding

    private Style _headerStyle;
    // etc. etc. 
    public SetColumns
    {
        _headerStyle = new Style(typeof(HeaderContentControl));
        _headerStyle.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Bold));
        ParamColumns.Add(new GridColumn
        {
            ColumnHeaderContentStyle = _headerStyle,
            FieldName = "ParamName",
            Width=80,
            Header="Parameter"
        });
        ParamColumns.Add(new GridColumn
        {
            ColumnHeaderContentStyle = _headerStyle,
            FieldName = "ParamValue",
            Width=50,
            Header="Value"
        });

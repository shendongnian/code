    void grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if(e.Column is DataGridCheckBoxColumn)
        {
            var checkBoxColumn = e.Column as DataGridCheckBoxColumn;
            var resource =     Application.Current.FindResource(typeof(CheckBox));
            checkBoxColumn.ElementStyle = resource as Style;
        }
    }

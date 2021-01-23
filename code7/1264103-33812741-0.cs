    GridViewTextBoxColumn yazarColumn = new GridViewTextBoxColumn("UniqueNameYazarColumn");
    yazarColumn.Name = "UniqueNameYazarColumn";
    textBoxColumn.HeaderText = "Your header";
    textBoxColumn.FieldName = "yazar"; //Field is name of the bounded property of source
    //add column to the grid
    MyRadGridView.Columns.Add(yazarColumn);

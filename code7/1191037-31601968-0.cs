    private void dataGridView1_CellFormatting(object sender,
                                              DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
        DataGridViewColumn column = this.dataGridView1.Columns[e.ColumnIndex];
        //For getting right column you can compare to the index
        //Or as in this example comparing to the names of the predefined columns
        if (column.Name.Equals(this.ColumnMapperInfoNumber.Name) == true)
        {
            MapperInfo temp = e.Value as MapperInfo;
            if (temp != null)
                e.Value = temp.Number;
        }
        else if(column.Name.Equals(this.ColumnMapperInfoProp1.Name) == true)
        {
            MapperInfo temp = e.Value as MapperInfo;
            if (temp != null)
                e.Value = temp.Prop1;  
        }
        else if(column.Name.Equals(this.ColumnMapperInfoProp2.Name) == true)
        {
            MapperInfo temp = e.Value as MapperInfo;
            if (temp != null)
                e.Value = temp.Prop2;
        }        
    }

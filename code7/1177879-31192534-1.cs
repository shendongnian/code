    private void  dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].name=="MyEnumColumnName")
        { 
           MyEnumType enumValue = (MyEnumType)e.value ;
           string enumstring = ... ; // convert here the enum to displayed string 
           e.Value = enumstring ;
         }
    }

    private void  dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].name=="MyEnumColumnName"])
        { 
           MyEnumType enumValue = e.value ;
           string enumstring = ... ; // convert here the enum to displayed string 
           e.Value = enumstring() 
         }
      }
      if (e.ColumnIndex==3 && e.Value.ToString().StartsWith("ERROR")) e.CellStyle.BackColor = Color.Yellow;
    }

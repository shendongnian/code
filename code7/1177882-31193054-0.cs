    private void  dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView.Columns[e.ColumnIndex].Name == "MyEnumColumn")
        { 
           SomeEnum enumValue = (SomeEnum)e.value ;
           e.Value = ((XmlEnumAttribute)typeof(SomeEnum).GetMember(enumValue.ToString()).FirstOrDefault().GetCustomAttributes(typeof(XmlEnumAttribute)).FirstOrDefault()).Description ;
         }
    }

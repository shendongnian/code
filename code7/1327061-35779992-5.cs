    datagridview1.DataSource = null;
    datagridview1.Columns.Clear();  //Just make sure things are blank.
    
    datagridview1.Columns.Add("Column1","Column1");
    datagridview1.Columns.Add("Column2","Column2");
    datagridview1.Columns.Add("Column3","Column3");
    
    datagridview1.Rows.Clear();
    for(int i = 0;i<10;i++)
    {
        datagridview1.Rows.Add()
    }
    datagridview1.EditMode = DataGridViewEditMode.EditOnKeystroke;

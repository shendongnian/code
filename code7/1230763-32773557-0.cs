    for(int i=0; i<dataRow.Table.Columns.Count; i++)
    { 
       dt.Rows.Add(GridView1.SelectedRow.Cells[i2].Text);
       i2++;
    }
    GridView2.DataSource = dt;
    GridView2.DataBind();

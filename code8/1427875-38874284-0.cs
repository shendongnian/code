    protected void Button1_Click(object sender, EventArgs e)
        {
            var dt2 = new DataTable();
            dt2.Columns.Add("col1", typeof(string));
            dt2.Columns.Add("col2", typeof(string));
            /....
    
            int row = gv1.Rows.Count;
            int col = gv1.Rows[0].Cells.Count;
    
            for (int i = 0; i < row; i++)
            {
                DataRow rw = dt2.NewRow();
                for (int j = 0; j < col; j++)
                {
                    rw[j] = gv1.Rows[i].Cells[j].Text;
                }
                dt2.Rows.Add(rw);
            }
    
           gv2.DataSource = dt2;
           gv2.DataBind();
        }

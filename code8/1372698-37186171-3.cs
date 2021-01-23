    protected void GenerateGridColumn()
    {
        int colsCount = Convert.ToInt32(tbxCol.Text);
        TemplateField tfield;
        BoundField bfield = new BoundField();
        bfield.HeaderText = "";
        for (int col = 0; col <= colsCount; col++)
        {
            tfield = new TemplateField();
            tfield.HeaderText = "D-" + col;
            gv.Columns.Add(tfield);
        }
        tfield = new TemplateField();
        tfield.HeaderText = "Supply";
        gv.Columns.Add(tfield);
    }
    protected void btnGenerate_OnClick(object sender, EventArgs e)
    {
        GenerateGridColumn();
        int rowsCount = Convert.ToInt32(tbxRow.Text);
        DataTable dt = new DataTable();
        for (int i = 0; i <= rowsCount; i++)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }
        gv.DataSource = dt;
        gv.DataBind();
        btnSave.Visible = true;
    }
    
    protected void gv_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i > 0)
                {
                    TextBox txt = new TextBox();
                    txt.ID = "tbx" + i;
                    e.Row.Cells[i].Controls.Add(txt);
                }
            }
        }
    }

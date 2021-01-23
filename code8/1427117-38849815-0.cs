    Gridview_ActionPlan.DataBind();
    DataSet t = new DataSet();
    var gv = Gridview_ActionPlan;
    string GridID = Convert.ToString(gv.ID);
    using (SqlConnection objConn = new SqlConnection("Data Source=XXXXXX"))
    using (SqlCommand objCommand = new SqlCommand(@"select Text
                                        from EPC_Menu
                                        where language = @language and MenuControlID = @GridID
                                        order by MenuID", objConn))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        objCommand.Parameters.Add("@GridID", SqlDbType.NVarChar).Value = GridID;
        objCommand.Parameters.Add("@language", SqlDbType.NVarChar).Value = LanguageLabel.Text;
        adapter.SelectCommand = objCommand;
        adapter.Fill(t);
    }
    var headerRow = gv.HeaderRow;
    for (int i = 0; i + 6 < gv.Columns.Count; i++)
    {
        if (t.Tables[0].Rows.Count > 0)
        {
            headerRow.Cells[i + 6].Text = t.Tables[0].Rows[i][0].ToString();
        }
    }
    for (int i = 0; i < gv.Rows.Count; i++)
    {
        if (gv.Rows[i].Cells[1].Text == "True")
        {
            gv.Rows[i].Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
            gv.Rows[i].Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
        }
        else if (gv.Rows[i].Cells[2].Text == "2")
        {
            gv.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#CCECF4");
        }
        if (gv.Rows[i].Cells[3].Text != "1" && 
            gv.Rows[i].Cells[2].Text != "2" && 
            !string.IsNullOrEmpty(gv.Rows[i].Cells[3].Text) &&
            gv.Rows[i].RowType == DataControlRowType.DataRow && 
            Gridview_ActionPlan.EditIndex != gv.Rows[i].RowIndex)
        {
            LinkButton LB2 = gv.Rows[i].FindControl("ButtonOpen") as LinkButton;
            LB2.Visible = true;
        }
    }
  

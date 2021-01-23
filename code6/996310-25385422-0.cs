    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    int index = GridView1.SelectedIndex;
                    this.pcode = GridView1.Rows[index].Cells[0].Text;
        
                }
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        // Get reference to button field in the gridview.  
                        LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                        string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "Select$" + e.Row.RowIndex);
                        e.Row.Style["cursor"] = "hand";
                        e.Row.Attributes["onclick"] = _jsSingle;
                    }
                }
            }
    
    
            protected override void Render(HtmlTextWriter writer)
            {
                foreach (GridViewRow r in GridView1.Rows)
                {
                    if (r.RowType == DataControlRowType.DataRow)
                    {
                        for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                        {
                            Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                        }
                    }
                }
                base.Render(writer);
            }
    
            protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName.ToString() == "ColumnClick")
                {
                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        if (r.RowType == DataControlRowType.DataRow)
                        {
                            for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                            {
                                r.Cells[columnIndex].Attributes["style"] += "background-color:White;";
                            }
                        }
                    }
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    // int selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    GridView1.Rows[selectedRowIndex].Cells[1].Attributes["style"] += "background-color:Red;";
                    TextBox2.Text = GridView1.Rows[selectedRowIndex].Cells[2].Text; 
                    
                }
            }

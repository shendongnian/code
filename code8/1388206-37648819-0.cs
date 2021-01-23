    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl = e.Row.FindControl("ddlOpt") as DropDownList;
                string val = e.Row.Cells[2].Text;
                
                if (ddl != null)
                {
                    Dictionary<string, string> list = new Dictionary<string, string>();
                    list.Add("", "");
                    list.Add("0", "No");
                    list.Add(val, "Yes");
                    ddl.DataSource = list;
                    ddl.DataTextField = "Value";
                    ddl.DataValueField = "Key";
                    ddl.DataBind();
                }
            }
        }

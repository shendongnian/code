        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    DropDownList ddl = e.Row.FindControlRecursive("dhl") as DropDownList;
                    DropDownList stageDDL = e.Row.FindControlRecursive("dhl") as DropDownList;
                    stageDDL.DataSource = this.clservice.Getstuff("someparam");
                    stageDDL.DataTextField = "columnx";
                    stageDDL.DataValueField = "columnx";
                    stageDDL.DataBind();
                }
            }
        }

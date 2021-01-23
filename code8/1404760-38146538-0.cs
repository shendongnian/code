    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateGCommand")
            {
                if (IsPostBack)
                {
                    
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    GridViewRow row = GridView4.Rows[RowIndex];
                    //Actual edited values for this row
                    //Name
                    string name = ((TextBox)row.FindControl("textBox1")).Text.ToString();
                    //Mail
                    string mail = ((TextBox)row.FindControl("textBox2")).Text.ToString();
                    //Mobile
                    string mobile = ((TextBox)row.FindControl("textBox3")).Text.ToString();
                    // Here you have all the edited row informations, you can do whatever you want with it
                }
            }
        }

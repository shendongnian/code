        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {   
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label userIdLbl = (Label)e.Row.FindControl("lbl_UserID");
                LinkButton editBt = (LinkButton)e.Row.FindControl("Edit");
                editBt.Visible = currentUserId == Convert.ToInt32(userIdLbl.Text);
            }
        }

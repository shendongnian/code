        protected void gvSignInRegister_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void gvSignInRegister_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        protected void gvSignInRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvSignInRegister.Rows[e.RowIndex];
            TextBox tb = (TextBox)row.FindControl("txtReturned");
            //Use the tb for updating database or to do any logic    
        }

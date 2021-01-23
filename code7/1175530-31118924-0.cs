        protected void gvTerm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TextBox txtCountryRate_Te = (TextBox)gvTerm.Rows[e.RowIndex].FindControl("txtCountryRate_Te");
            if (txtCountryRate_Te == null)
            {
                txtCountryRate_Te = new TextBox
                {
                    Text = String.Empty
                };
            }
        }

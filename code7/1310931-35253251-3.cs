        protected void gvSignInRegister_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSignInRegister.EditIndex = e.NewEditIndex;
            List<QuotationDetail> itemList = (List<QuotationDetail>)ViewState["ItemList"];
            gvSignInRegister.DataSource = itemList;
            gvSignInRegister.DataBind();
        }
        protected void gvSignInRegister_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        protected void gvSignInRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var txtQty = (TextBox)gvSignInRegister.Rows[e.RowIndex].FindControl("txtQuantity");
            decimal qty = 0;
            decimal.TryParse(txtQty.Text, out qty);
            if (qty < 0)
            {
                lblErrorSummary.InnerText = "Please provide valid Quantity";
                lblErrorSummary.Visible = true;
                return;
            }
            itemList[e.RowIndex].Quantity = qty
            ViewState["ItemList"] = itemList;
            gvSignInRegister.EditIndex = -1;
            gvSignInRegister.DataSource = itemList;
            gvSignInRegister.DataBind();
        }

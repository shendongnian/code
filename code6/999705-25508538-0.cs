      protected void CartGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
            if (CartGrid.DirtyRows.Count > 0)
            {
                Label lblShoppingCartId = (Label)CartGrid.Rows[e.RowIndex].FindControl("lblShoppingCartId");
                var cartid = lblShoppingCartId.Text;
                //find out which rows were updated
                foreach (GridViewRow row in CartGrid.DirtyRows)
                {
                    string lblArtnr = row.Cells[0].Text;
                    TextBox txtQuantity = row.Cells[2].Controls[0] as TextBox;
                    LinqtoDBDataContext db = new LinqtoDBDataContext();
                    db.ShoppingCartUpdateQuantity(Convert.ToInt32(lblShoppingCartId.Text), Convert.ToInt32(txtQuantity.Text), lblArtnr);
                }
                FillGrid(Convert.ToInt32(cartid));
                alertdiv.Attributes.Add("class", "alert alert-success");
                alertdiv.Controls.Add(new LiteralControl("Kundvagnen updaterad"));
                alertdiv.Visible = true;
            }
            else
            {
                alertdiv.Attributes.Add("class", "alert alert-danger");
                alertdiv.Controls.Add(new LiteralControl("FEL! Kundvagnen ej updaterad"));
                alertdiv.Visible = true;
            }
            }
            catch (Exception)
            {
                alertdiv.Attributes.Add("class", "alert alert-danger");
                alertdiv.Controls.Add(new LiteralControl("FEL! Kundvagnen ej updaterad"));
                alertdiv.Visible = true;
            }
        }

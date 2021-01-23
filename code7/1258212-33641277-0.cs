    Checkbox oRb2 = (Checkbox )r.FindControl("rb_grid");double total = 0;
    foreach (DataGridItem oItem in grid.Items)
    {    
        if (oRb2.Checked == true)
        {
            total += GvProducts.Rows.Cast<GridViewRow>().Sum(r => double.Parse(((TextBox)r.FindControl("txtQuantity")).Text) * double.Parse(((TextBox)r.FindControl("txtUnitprice")).Text));
        }
    }

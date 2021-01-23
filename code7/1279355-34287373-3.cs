    var validRows = from r in gridpur.Rows.Cast<GridViewRow>()
        where ((CheckBox)r.FindControl("chkSel")).Checked)
        select r;
    var totals = from r in validRows
       select double.Parse(((TextBox)r.FindControl("txtQuantity")).Text)
        * double.Parse(((TextBox)r.FindControl("txtUnitprice")).Text));

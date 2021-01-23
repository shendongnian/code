    // From your code
    var validRows = gridpur.Rows.Cast<GridViewRow>()
        .Where(r => ((CheckBox)r.FindControl("chkSel")).Checked);
    var totals = validRows.Select((r => 
        double.Parse(((TextBox)r.FindControl("txtQuantity")).Text)
        * double.Parse(((TextBox)r.FindControl("txtUnitprice")).Text));
    

    var calculateDiscount = double.Parse(txtdiscount.Text) / 100;
    double total = gridpur.Rows.Cast<GridViewRow>()
        .Select(r => Tuple.Create((CheckBox)r.FindControl("chkSel"), (TextBox)r.FindControl("txtQuantity"), (TextBox)r.FindControl("txtUnitprice")))
        .Where(t => t.Item1.Checked)
        .Sum(r => double.Parse(t.Item2.Text) * double.Parse(t.Item3.Text) * calculateDiscount);

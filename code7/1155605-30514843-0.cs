    private void cbo_SelectedValueChanged(object sender, EventArgs e)
    {
        if (cbo.SelectedValue == null)
            return;
        var item = (MyEnum)cbo.SelectedValue;
        if (item == MyEnum.Customer)
        { //Do someting... }
    }

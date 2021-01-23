    Datatable dt = new Datatable();
    dt.Columns.Add("StatusVal", typeof(bool));
    dt.Columns.Add("InvVal", typeof(string));
    foreach()
    {
        dt.Rows.Add(new object[2]{loopdetail.Status, loopdetail.InvVal});
    }
    shoppingcartlines.DataSource = dt;
    shoppingcartlines.DataBind();

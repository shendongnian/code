    private void GetMemDetail()
    {
        var result = (from c in db.Customers
                      where c.CustomerID == thisCustomerID
                      select c).FirstOrDefault();
        //result.Birthday is '1990/5/10'
        //ddl_y item can't be selected, but ddl_m and ddl_d can
        ddl_y.Items.FindByValue(result.Birthday.Value.Year.ToString()).Selected = true;
        ddl_m.Items.FindByValue(result.Birthday.Value.Month.ToString()).Selected = true;
        dateDayBind();
        ddl_d.Items.FindByValue(result.Birthday.Value.Day.ToString()).Selected = true;
    }

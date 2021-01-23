    List<Title> cartItems = (List<Title>)Session["eStoreCart"];
    int userid = Int32.Parse(Session["eStoreUserId"].ToString());
    
    using (var ebs = new MyDbContext())
    {
        User us = ebs.Users.SingleOrDefault(u => u.UserId == userid);
        Bill bl = new Bill();
        bl.BillAmount = Decimal.Parse(lblBill.Text);
        bl.BillDate = DateTime.Now;
        foreach (Title item in cartItems)
            bl.Titles.Add(item);
        us.Bills.Add(bl);
        ebs.SaveChanges();
    }
    Response.Redirect("Orders.aspx");

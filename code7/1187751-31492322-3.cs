    List<int> cartItemIds = (List<int>)Session["eStoreCart"];
    int userid = Int32.Parse(Session["eStoreUserId"].ToString());
    
    using (var ebs = new MyDbContext())
    {
        User us = ebs.Users.SingleOrDefault(u => u.UserId == userid);
        Title title = null;
        Bill bl = new Bill();
        bl.BillAmount = Decimal.Parse(lblBill.Text);
        bl.BillDate = DateTime.Now;
        foreach (var id in cartItems)
        {
            title = ebs.Titles.Where(t => t.Id == id);
            bl.Titles.Add(title);
        }
        us.Bills.Add(bl);
        ebs.SaveChanges();
    }
    Response.Redirect("Orders.aspx");

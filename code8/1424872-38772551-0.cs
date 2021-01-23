    decimal grandTotal = 0;
    //...
    using(var dataContext = new CAPEXDataConnDataContext())
    {
       rptProjects.DataSource = dataContext.web_CAPEXProjectsByCompany(Session["PropertyNumber"].ToString());
       grandTotal = 0;
       rptProjects.DataBind();
    }
    //...
    protected void rptProjects_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType = ListItemType.AlternatingItem)
       {
          grandTotal += (decimal)e.Item.DataItem["TotalAmount"];
       }
       if(e.Item.ItemType == ListItemType.Footer)
       {
          ((Literal)e.Item.FindControl("grandTotal")).Text = grandTotal.ToString("C");
       }
    }
  

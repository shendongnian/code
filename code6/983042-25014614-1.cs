            protected void Page_Load(object sender, EventArgs e)
        {
            LinqtoDBDataContext db = new LinqtoDBDataContext();
            ParentRepeater.DataSource = db.GetParentCategories();
            ParentRepeater.DataBind();
        }
        protected void ParentRepeater_OnItemBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dynamic cat = e.Item.DataItem as dynamic;
                int parentcatid = Convert.ToInt32(cat.ParentCatID);
                LinqtoDBDataContext db = new LinqtoDBDataContext();
                //var cats = from c in db.Categories
                //           where c.ParentCatID == parentcatid
                //          select c;
                Repeater ParentCatRepeater = e.Item.FindControl("ParentCatRepeater") as Repeater;
                ParentCatRepeater.DataSource = db.GetCategories(parentcatid);
                ParentCatRepeater.DataBind();
            }
        }
        protected void ChildRepeater_OnItemBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dynamic prod = e.Item.DataItem as dynamic;
                int catid = Convert.ToInt32(prod.CategoryID);
                LinqtoDBDataContext db = new LinqtoDBDataContext();
                Repeater ChildRepeater = e.Item.FindControl("ChildRepeater") as Repeater;
                ChildRepeater.DataSource = db.GetProductsInCategory(catid);
                ChildRepeater.DataBind();
            }
        }
 
    }

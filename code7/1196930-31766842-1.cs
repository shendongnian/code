    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DisplayCarousel();
        }
    }
    protected void DisplayCarousel()
    {
        using (Entities db = new Entities())
        {
            // get all your data first
            var DataList = db.Brands
                .Select(a => new
                {
                    objBrand = a,
                    PicList = a.Pics.ToList()
                })
                .OrderByDescending(a => a.objBrand.date_created)
                .ToList();
    
    
            // now bind the main listview to the Brand objects in the DataList
            lvCarousel.DataSource = Brands.Select(a => a.objBrand);
            lvCarousel.DataBind();
    
            foreach (ListViewItem objItem in lvCarousel.Items)
            {
                // get the data object
                var objData = DataList[objItem.DataItemIndex];
    
                // find the nested list view
                ListView lvCarouselPic = (ListView)objItem.FindControl("lvCarouselPic");
    
                // bind the data pics data source
                lvCarouselPic.DataSource = objData.PicList;
                lvCarouselPic.DataBind();
    
                // loop each pic item
                foreach (ListViewItem objNestedItem in lvCarouselPic.Items)
                {
                    // get the pic object
                    var objBrandPic = objData.PicList[objNestedItem.DataItemIndex];
    
                    // do whatever you need with the pic data, find controls in the nested listview, etc.
                }
            }
        }
    }

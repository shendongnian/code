    using (Entities db = new Entities())
        {
            List<Brand> brand = db.Brands.ToList();
            lvCarousel.DataSource = brand.OrderByDescending(b => b.date_created);
            lvCarousel.DataBind();
            foreach (ListViewItem objItem in lvCarousel.Items)
            {
                // find the nested list view
                ListView lvCarouselPic = (ListView)objItem.FindControl("lvCarouselPic");
                // bind the data source
                lvCarouselPic.DataSource = brand.Pics;
                lvCarouselPic.DataBind();
            }
        }

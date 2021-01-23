    public void databind(string filter = null)
    {
        var filterQuery = "";
        if(!string.IsNullOrEmpty(filter)){
            filterQuery = " AND c.category_code = '" + filter + "'";
            this.ViewState.ContainsKey("filter") 
                ? this.ViewState["filter"] = filter
                : this.ViewState.Add("filter", filter);
        }
        var query = "select p.item_code as pitem, i.LongDesc as longname, p.SellPrice_1 as normalprice, p.SellPrice_2 as memberprice from plu p inner join item i on p.item_code = i.item_code WHERE p.publish =1";
        query += filterQuery;
        query += " order by i.LongDesc";
        
        adap = new SqlDataAdapter(query, constr);
        ds = new DataSet();
        adsource = new PagedDataSource();
        adap.Fill(ds);
        adsource.DataSource = ds.Tables[0].DefaultView;
        adsource.PageSize = 16;
        adsource.AllowPaging = true;
        adsource.CurrentPageIndex = pos;
        CategoryList.DataSource = adsource;
        CategoryList.DataBind();
    }

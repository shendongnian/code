    private void PopulateOrders()
    {
      if (isFirstTrip == 1) 
      {
        CustomerInfo ki = CustomerInfoProvider.GetCustomerInfoByUserID(CooneenHelper.GetUserImpersonisationID());
        int nKustomerID = ki.CustomerID;
        /*
        DataTable dts = new DataTable();
        dts.Columns.Add("OrderDate", typeof(string));
        dts.Columns.Add("OrderItemSKUName", typeof(string));
        dts.Columns.Add("OrderItemSKUID", typeof(string));
        dts.Columns.Add("OrderItemStatus", typeof(string));
        dts.Columns.Add("OrderItemUnitCount", typeof(string));
        */
        
        QueryDataParameters qdp = new QueryDataParameters();
        qdp.Add("@CustomerID", nKustomerID);
        session("OrderList") = gc.ExecuteQuery("CN_OrderList", qdp, QueryTypeEnum.StoredProcedure, true);
    
        /*DataSet ds = gc.ExecuteQuery("CN_OrderList", qdp, QueryTypeEnum.StoredProcedure, true);
    
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
          DataRow drNew = dts.NewRow();
          drNew["OrderDate"] = ValidationHelper.GetDateTime(dr["OrderDate"], DateTime.Now).ToShortDateString();
          drNew["OrderItemSKUName"] = dr["OrderItemSKUName"].ToString();
          drNew["OrderItemSKUID"] = dr["OrderItemSKUID"].ToString();
          drNew["OrderItemStatus"] = dr["OrderItemStatus"].ToString();
          drNew["OrderItemUnitCount"] = dr["OrderItemUnitCount"].ToString();
          dts.Rows.Add(drNew);
        }*/
      } 
      isFirstTrip = 0;
      PagedDataSource pds = new PagedDataSource();
      pds.DataSource = DirectCast(session("OrderList"),DataTable).DefaultView;
      //pds.DataSource = dts.DefaultView;
      //DataView view = dts.DefaultView;  <- Not used
    
      //allow paging, set page size, and current page
      pds.AllowPaging = true;
      pds.PageSize = PerPage;
      pds.CurrentPageIndex = CurrentPage;
    
      //show # of current page in label
      if (pds.PageCount > 1) litResults.Text += " - Showing page " + (CurrentPage + 1).ToString() + " of " + pds.PageCount.ToString();
    
      //disable prev/next buttons on the first/last pages
      btnPrev.Enabled = !pds.IsFirstPage;
      btnNext.Enabled = !pds.IsLastPage;
    
      rprOrders.Visible = true;
    
      rprOrders.DataSource = pds;
      rprOrders.DataBind();
    
    }

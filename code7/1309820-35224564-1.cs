    if (!IsPostBack)
            {
                if (RouteData.Values["id"] != null)
                {
                   loadproduct();
    
                }
    }
    
    void loadproduct()
    {
     select .............  where id= RouteData.Values["id"].ToString();
    }

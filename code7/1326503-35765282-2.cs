    public List<GridView> Code
    {
        get
        {
            if (HttpContext.Current.Session["Code"] == null)
            {
                HttpContext.Current.Session["Code"] = new List<GridView>();
            }
            return HttpContext.Current.Session["Code"] as List<GridView>;
        }
        set
        {
            HttpContext.Current.Session["Code"] = value;
        }
    
    }

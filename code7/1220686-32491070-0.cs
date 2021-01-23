    public IEnumerable<SelectListItem> Items 
    {
        get
        {
            object values = HttpContext.Current.Session["MY_ITEMS_TO_LIST_FOR"];
            if (null == values)
            {
                return null;
            }
            else
            {
                return (IEnumerable<SelectListItem>)values;
            }
        }
        set
        {
            if (value.Count() > 0) //http post reset value
            {
                HttpContext.Current.Session["MY_ITEMS_TO_LIST_FOR"] = value;
            }
        }
    }

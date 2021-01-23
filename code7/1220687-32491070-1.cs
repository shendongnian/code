        public IEnumerable<SelectListItem> Items 
        {
            get
            {            
                if (HttpContext.Current.Session["MY_ITEMS_TO_LIST_FOR"] == null)
                {
                    return null;
                }
                else
                {
                    return (IEnumerable<SelectListItem>)HttpContext.Current.Session["MY_ITEMS_TO_LIST_FOR"];
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
    

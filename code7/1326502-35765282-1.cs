      public string RT
        {
            get
            {
                if (HttpContext.Current.Session["RT"] == null)
                {
                    HttpContext.Current.Session["RT"] = "" ;
                }
                return HttpContext.Current.Session["RT"] as string;
            }
            set
            {
                HttpContext.Current.Session["RT"] = value;
            }
    
        }

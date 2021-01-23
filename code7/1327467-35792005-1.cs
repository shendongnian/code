      public static class TaskManSession
    {
        public static int SelectedProjectId
        {
            get
            {
               if (System.Web.HttpContext.Current.Session["ProjectId"] ==null)
                   {
                     return 0;
                   }
                return Convert.ToInt32(System.Web.HttpContext.Current.Session["ProjectId"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["ProjectId"] = value;
            }
        }
    }

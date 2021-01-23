        [WebMethod(EnableSession=true)]
        public static object InsertData()
        {
             var name = HttpContext.Current.Request.QueryString["username"];
             var subject = HttpContext.Current.Request.QueryString["subject"];
             var desc = HttpContext.Current.Request.QueryString["desc"];
             
             // Do some work
        }

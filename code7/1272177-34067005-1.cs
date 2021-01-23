        [System.Web.Mvc.HttpPost]
        public String checkUsrPswd() // Post() per l'username e la password
        {
            IEnumerable<string> headerUsr = Request.Headers.GetValues("Usr");
            String usr = headerUsr.FirstOrDefault();
            IEnumerable<string> headerPswd = Request.Headers.GetValues("Pswd");
            String pswd = headerPswd.FirstOrDefault();
            ...
         }

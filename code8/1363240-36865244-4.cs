            public void ProcessRequest(HttpContext context)
        {
            var search = HttpContext.Current.Request.Form["term"];
            //Dummy Data
            List<string> searchList = new List<string> { "Red", "Orange", "Ping", "Blue", "White", "Black" };
            string result = string.Empty;
            if (!string.IsNullOrEmpty(search))
            {
                searchList = searchList.Where(x => x.ToLower().Contains(search.ToLower())).ToList();
            }
            if (searchList != null && searchList.Count() > 0)
            {
                foreach (var item in searchList)
                {
                    result += "<li>" + item + "</li>";
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

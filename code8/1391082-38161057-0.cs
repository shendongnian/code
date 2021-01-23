    using(var wc= new WebClient())
    {
           var nv = new System.Collections.Specialized.NameValueCollection();
           nv.Add("filename", "test");
           nv.Add("user", "bar");
           wc.UploadValues("http://stackoverflow.com/questions/ask", nv);
    }

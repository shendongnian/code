    using (myDbDataContext wdb = new myDbDataContext ())
        {
            Article ar = new Article();
            var a = from p in wdb.Articles
                    where p.Id == 16
                    select p.Text;
            blablablaText.InnerText = a.FirstorDefault().ToString();
        }

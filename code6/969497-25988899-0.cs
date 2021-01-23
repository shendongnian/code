    function IsFieldExists(field) {
       
       string siteUrl = "http://MyServer/sites/MySiteCollection";
       ClientContext clientContext = new ClientContext(siteUrl);
       SP.List List = clientContext.Web.Lists.GetByTitle("listTitle);
       for (int i = 0; i < list.Fields.Count; i++)
       {
         if (list.Fields[i].Title == field)
           return true;
       }
    }

        public ActionResult GMap()
        {
    
            var ReadJson = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/whateverthenameis.json"));
    
           RootObject json = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<RootObject>(ReadJson);
    
       return View(json.city);
    }

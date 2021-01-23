      [System.Web.Services.WebMethod]
        public static void GetLocations(int id, string type)
        {
         // var attractions = something ;
         
         var js = new System.Web.Script.Serialization.JavaScriptSerializer();
    
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(  js.Serialize(attractions )  );
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
       }

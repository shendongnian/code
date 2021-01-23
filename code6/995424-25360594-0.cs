    string jsonformatstring = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(jsonformatstring);
            HttpContext.Current.Response.End();
returns a String. To be used as Json you need to parse it, JsonConvert.SerializeObject only format the object into {[ key:value ]}.

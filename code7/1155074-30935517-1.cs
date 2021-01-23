     void Application_BeginRequest(object sender, EventArgs e)
            {
                var key = "ItemKey";
                if (!HttpContext.Current.Request.RawUrl.Contains("Back"))
                {
                    indexes.Add(++counter, HttpContext.Current.Request.RawUrl.Replace("/Home", ""));
                }
                HttpContext.Current.Items[key] = indexes;
            }
 

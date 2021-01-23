     var model = _db.FacebookInfo.OrderByDescending(f => f.Followers).ToList();
            var grid = new System.Web.UI.WebControls.GridView(); 
        grid.DataSource = (from u in model
                           select new
                           {
                               fullname = System.Text.RegularExpressions.Regex.Replace(u.FullName, "<span .*?>(.*?)", ""),
                               followers = u.Followers,
                               friends = u.Friends,
                               url = u.FbLink
                           }).ToList();
    
        grid.DataBind();
    
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=Nana bregvadze Friends.xls");
        Response.ContentType = "application/excel";
        Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
       
        grid.RenderControl(htw);
    
        Response.Write(sw.ToString());
    
        Response.End();

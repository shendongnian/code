    public void ProcessRequest(HttpContext context)
    {
        //get our username from the query string
        var username = context.Request.QueryString["username"];
    
        //clear the response and set the content type headers
        context.Response.Clear();
        context.Response.ContentType = "image/png";
    
        //if the username is empty then end the response with a 401 not found status code
        if (string.IsNullOrWhiteSpace(username))
        {
            context.Response.StatusCode = 401;
            context.Response.End();
            return;
        }
    
        //do a db query to validate the user. If not valid do a 401 not found
        bool isValidUser = new UserManager().IsValidUser(username);
        if (!isValidUser)
        {
            context.Response.StatusCode = 401;
            context.Response.End();
            return;
        }
    
        //get the user image file path from a server directory. If not found end with 401 not found
        string filePath = context.Server.MapPath(string.Format("~/App_Data/userimages/{0}.png", username));
        if (!System.IO.File.Exists(filePath))
        {
            context.Response.StatusCode = 401;
            context.Response.End();
            return;
        }
    
        //finish the response by transmitting the file
        context.Response.StatusCode = 200;
        context.Response.TransmitFile(filePath);
        context.Response.Flush();
        context.Response.End();
    }

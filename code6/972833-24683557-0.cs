    public void ProcessRequest(HttpContext context)
        {
        if(String.IsNullOrEmpty(context.Request.QueryString["file"]))
            {
            //return error status code telling them to provide a file
            context.Response.End();
            }
        string requestedfile=context.Request.QueryString["file"];
    
        if(HasAccess(User.Identity.Name, requestedfile))
           {
            //write the file to the response
           }
        else
           {
            //return error status code telling them they're unauthorized
            context.Response.End();
            }
        }
    
    public static bool HasAccess(string username, string file)
        {
        //if user has access to the file, return true. Else return false. This might involve database lookups etc
        }

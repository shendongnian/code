    public void ProcessRequest(HttpContext context) 
        { 
            Teachers_Att_Data teacherAttDataNew; 
    
            try 
            { 
                string xml = context.Request.Url.Query.ToString();
    
                context.Response.ContentType = "text/plain"; 
                context.Response.Write("updated");     
            }  
            catch (Exception ex) 
            { 
                      context.Response.Write("f"); 
            } 
        }

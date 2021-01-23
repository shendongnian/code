    public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "multipart/form-data";
            context.Response.Expires = -1;
            try
            {
                string callingFromPage = context.Request["callingFromPage"];
                if (!string.IsNullOrWhiteSpace(callingFromPage))
                {
                    switch (callingFromPage)
                    {
                        case "help":
                            {
                                string requestType = context.Request["requestType"];
                                string description = context.Request["description"];
                                HttpPostedFile photo = context.Request.Files[0];
                                string guid = context.Request["userGUID"];
                                //DO YOUR STUFF >>>
                                context.Response.Write("success");
                                break;
                            }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

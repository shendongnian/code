    if (IsPostBack)
                    {
                        if(! string.IsNullOrEmpty(Request.Form["Button2"]))
                            Response.Write("{Button2  was clicked");
                      
                    }

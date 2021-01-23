    var method = this.Page.RouteData.Values["meth"] as string;
                    if (string.IsNullOrEmpty(method))
                    {
                        method = this.Page.Request.QueryString["meth"];
                    }
                    if (string.IsNullOrEmpty(method))
                    {
                        method = this.Page.Request.Form["meth"];
                    }
                    if (string.IsNullOrEmpty(method))
                    {
                        throw new Exception("Method was not specified");
                    }

    if (!(Page.User.IsInRole("Domain\\Security Group")) && !(Page.User.IsInRole("Domain\\SG2"))
                    && !(Page.User.IsInRole("Domain\\SG3")) && Page.User.Identity.Name != "Domain\\USER")
                {
                    Server.Transfer("~/AccessDenied.aspx");
                }

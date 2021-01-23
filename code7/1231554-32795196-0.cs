                if (!IsPostBack)
                {
                if (Session["LoginUser"]!=null && string.IsNullOrEmpty(Session["LoginUser"].ToString()) == false && string.IsNullOrEmpty(Session["CustomerId"].ToString()) == false)//error
                    {
                    if (Session["LoginUser"].ToString() == "admin")
                        {
                        DDlUsers.Visible = true;
                        fillusers();
                        }
                    else if (Session["LoginUser"].ToString() != "admin" && Session["CustomerId"].ToString() == "True")
                        {
                        DDlUsers.Visible = false;
                        //fillusers();
                        }
                    else
                        {
                        DDlUsers.Visible = false;
                        }
                    FillProjectList();
                    Pnl_Link.Visible = false;
                    Pnl_Status.Visible = false;
                    }
                else
                    {
                    Response.Redirect("~/login.aspx");
                    }
    
                }

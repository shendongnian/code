    if(!mCheckStatusOfSession())
    {
    Response.Redirect("To Login Page")
    }
    protected void mCheckStatusOfSession{
                   if (Application[Session["UserName"].ToString()] == null)
                    {
                        return false;
                    }
                    else
                    {
                    Application[Session["UserName"].ToString()].ToString();
                        if (strID == Session.SessionID.ToString())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
    }

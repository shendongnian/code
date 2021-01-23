    //set breakpoint here to make sure you get an A
    AccessLevel = LogInData.userInfo[0].userAccessLvl.ToString();
    
        switch (AccessLevel)
        {
            case "A":
    
                Session["UserName"] = txtUserName.Text;
                Session["AccessLevel"] = "A";
                Response.Redirect("adminArea.aspx");
                break;
    
            case "S":
                Session["UserName"] = txtUserName.Text;
                Session["AccessLevel"] = "S";
                Response.Redirect("customerAcctArea.aspx");
                break;
    
            default:
                break; //you are just falling through to here, not redirecting.
        }

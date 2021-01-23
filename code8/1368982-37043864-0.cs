    public static string logedin(string uname, string password)
    {
        tbl_user_login objLogedin = new tbl_user_login();
        DataTable dtb = new DataTable();
        dtb=objLogedin.loginUser(uname, password);
        //result=dtb.Columns[0].ToString();
        if (dtb.Rows.Count > 0)
        {
             return "valid";
        }
        else 
        {
            return "invalid";            
        }
    }

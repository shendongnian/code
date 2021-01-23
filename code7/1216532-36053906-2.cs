    [ActionName("Youractionname")]
    public Object Login(string emailid, string Passowrd)
    {
        if (emailid == null || Passowrd == null)
        {
            geterror gt1 = new geterror();
            gt1.status = "0";
            gt1.msg = "All field is required";
            return gt1;
        }
        else
        {
            string StrConn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            string loginid = emailid;
            string Passwrd = Passowrd;
            DataTable dtnews = new DataTable();
            SqlConnection con = new SqlConnection(StrConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_loginapi_app", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@emailid", loginid);
            SqlParameter p2 = new SqlParameter("@password", Passowrd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            da.Fill(dtnews);
            if (dtnews.Rows[0]["id"].ToString() == "-1")
            {
                geterror gt1 = new geterror();
                gt1.status = "0";
                gt1.msg = "Invalid Username or Password";
                con.Close();
                return gt1;
            }
            else
            {
                dtmystring.Clear();
                dtmystring.Columns.Add(new DataColumn("id", typeof(int)));
                dtmystring.Columns.Add(new DataColumn("Name", typeof(string)));
                dtmystring.Columns.Add(new DataColumn("Password", typeof(string)));
                dtmystring.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dtmystring.Columns.Add(new DataColumn("Emailid", typeof(string)));
                DataRow drnew = dtmystring.NewRow();
                drnew["id"] = dtnews.Rows[0]["id"].ToString();
                drnew["Name"] = dtnews.Rows[0]["Name"].ToString();
                drnew["Password"] = dtnews.Rows[0]["Password"].ToString();
                drnew["MobileNo"] = dtnews.Rows[0]["MobileNo"].ToString();
                drnew["Emailid"] = dtnews.Rows[0]["emailid"].ToString();
                dtmystring.Rows.Add(drnew);
                gt.status = "1";
                gt.msg = dtmystring;
                con.Close();
                return gt;
            }
        }
    }

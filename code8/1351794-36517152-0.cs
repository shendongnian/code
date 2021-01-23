    // Uncomment next line and update LoginTime variable to hold your Login Time as you inserted in Login Tables upon user login.
    // LoginTime =
    SqlConnection conlog = new SqlConnection(ConfigurationManager.ConnectionStrings["loginConnectionString"].ConnectionString);
    conlog.Open();
    Session["New"] = null;
    string idQuery = "Select ID from [Table] where Username='" + Label1.Text + "'";
    SqlCommand idd = new SqlCommand(idQuery, conlog);
    string strQuery = "update logindata set LogoutTime='" + DateTime.Now + "' where UserName='" + Label1.Text + "' AND LoginTime = '" + LoginTime + "'";
    SqlCommand cmd = new SqlCommand(strQuery, conlog);
    
    DateTime.Now.ToString());
    cmd.ExecuteNonQuery();
    Response.Redirect("Loginform.aspx");
    conlog.Close();

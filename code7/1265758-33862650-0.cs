        public DBManager
        {
            public void userLogin(User user)
            {
                using (SqlConnection _conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.uselogin",_conn))
                    {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@userNickName", user.UserNickName);
                       cmd.Parameters.AddWithValue("@userPassword", user.UserPassword);
                       using (SqlDataReader rd = cmd.ExecuteReader())
                       {
                           if (rd.HasRows)
                           {
                               HttpContext.Current.Response.Redirect("PublishingAnEvent.aspx", true);
                           }
                           else
                           {
                               //. Label5.Text = "do it again";
                               HttpContext.Current.Response.Redirect("RegistrationPage.aspx", true);
                           }
                       }
                   }
                }
            }
        }

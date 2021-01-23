    if (temp == 1)
    {
       conn.Open();
       string checkPassword = "select * from UserData where Username ='" + txtUser.Text + "'";
       SqlCommand passCom = new SqlCommand(checkPassword, conn);
       using (SqlDataReader oReader = passCom.ExecuteReader())
       {
          while (oReader.Read())
          {
            if(oReader["UserName"].ToString().Replace(" ", "") == txtPassword.Text.Trim())
            {
               Session["Username"]  = oReader["FirstName"].ToString();
               Session["Contact"]  = oReader["Contact"].ToString(); 
               Session["Email"] = oReader["Email"].ToString();
               Session["DeliveryAddress"] = oReader["DeliveryAddress"].ToString();
               Response.Redirect("OrderNow.aspx");
            }
            else
            {
               lblcrederror.Text = ("Credentials dont match");
               break;
            }                      
          }
          myConnection.Close();
       }
    }

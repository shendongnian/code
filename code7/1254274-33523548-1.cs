        protected void Button1_Click(object sender, EventArgs e) {
         try
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
             conn.Open();
             {
                 bool Accept = false;
                 bool Decline = false;
                 foreach (ListViewDataItem item in ListView1.Items)
                 {
                     CheckBox findcheckbox = (CheckBox)item.FindControl("AcceptCheckbox");
                     if (findcheckbox.Checked)
                     {
                         Accept = true;
                         Decline = false;
                     }
                     else
                     {
                         Accept = false;
                         Decline = true;
                     }
                 }
                 string selectString = "UPDATE Offers SET (Accept, Decline VALUES ('" + Accept + "', '" + Decline + "')";
                 SqlCommand usersql = new SqlCommand(selectString, conn);
                 usersql.ExecuteNonQuery();
                 Response.Write("<script type='text/javascript'>");
                 Response.Write("alert('You have made your decision');");
                 Response.Write("document.location.href='Offers.aspx';");
                 Response.Write("</script>");
             }
         }
         catch(Exception ex)
         {
             throw ex;
         }
        }

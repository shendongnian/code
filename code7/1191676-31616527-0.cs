    protected void Button2_Click(object sender, EventArgs e)
    {
         foreach(var control in Page.Controls)
       {
          if(control is TextBox)
          {
    
            if(((TextBox)control).ID.IndexOf("txtDynamic") != -1)
            {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO TI_Homes(CustomerID, Year, Make, Size, Owed, Offer, Wholesale) VALUES('1000', @name, @year, '80ft', '100,000', '80,000', 'Wholesale?')"))
                {
    
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", ((TextBox)control).Text);
                    cmd.Parameters.AddWithValue("@year", (pnl.FindControl("txtDynamic2") as TextBox).Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
              }
            }
          }
         }
       }
    }

       protected void rpCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
                SqlConnection conn;
                SqlCommand comm;
                string connectionString = ConfigurationManager.ConnectionStrings["ShqiptarConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (e.CommandName == "Delete")
                {
                comm = new SqlCommand("Delete from TBLCATEGORIES where CategoryID=" + e.CommandArgument, conn);
                comm.ExecuteNonQuery();
                }
                conn.Close();
                conn.Dispose();
                DeleteMsg.Visible = true;
               //Rebind here: this.BindRepeater();
        }

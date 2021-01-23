        private void BindGrid()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT * FROM Table_RegistrationInfo";
            string condition = string.Empty;
            foreach(ListItem item in CheckBoxList1.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if(!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" where Nationality in ({0})", condition.Substring(0, condition.Length - 1));
            }
            string condition2 = string.Empty;
            foreach(ListItem item in CheckBoxList2.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if(!string.IsNullOrEmpty(condition2))
            {
             if(!string.IsNullOrEmpty(condition))
                {
                condition+=" And ";
                }
           else {
                Condition +=" Where "
                }
          
      //condition = string.Format(" where Nationality in ({0})", condition.Substring(0, condition.Length - 1));
                condition2 = string.Format(" GivenName in ({0})", condition2.Substring(0, condition2.Length - 1));
            }
            SqlCommand cmd = new SqlCommand(query + condition + condition2);
            using(SqlConnection con = new SqlConnection(conString))
            {
                using(SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using(DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                }
            }
        
        }

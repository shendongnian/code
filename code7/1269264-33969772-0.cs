    using (MySqlCommand MySqlCommand = new MySqlCommand("SELECT FatherFullName FROM xxxxxx where sssss='xxxxx'", con))
        {
            MySqlCommand.CommandType = CommandType.Text;
            con.Open();
            DataTable dt = MySqlCommand.ExecuteTable();
            if(dt.Rows.Count > 0)
            {
               CheckBoxList1.DataSource = dt;
               CheckBoxList1.DataTextField = "Title";
               CheckBoxList1.DataValueField = "ArticleID";
               CheckBoxList1.DataBind();
            }
                       con.Close();   
    
        }

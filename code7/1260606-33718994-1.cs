    protected void RepeaterActivities_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // leave out the TextBox TextBoxID = (TextBox)item.FindControl("TextBoxID");
        // all your other code here...
        else if (e.CommandName == "doneBtn")
        {
            string id = Request.Form["TextBoxId"];
            SqlConnection conn = new SqlConnection(@"data source = localhost; user = root; password = toor; database = dblocal");
            SqlCommand cmd = null;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update";
                SqlParameter doneActID = cmd.Parameters.Add("@ActivityID", SqlDbType.Int);
                doneActID.Direction = ParameterDirection.Input;
                doneActID.Value = id;
           // rest of your code...

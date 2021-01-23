    protected void updateButtonModule_Click(object sender, EventArgs e)
    {
        feedback.Visible = true;
        feedback_text.Text = "Please ensure you've filled out all fields. ";
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (var myConnection = new SqlConnection(connectionString)) // using automatically disposes of object
        {
            myConnection.Open();
            string addModule = "INSERT into modules (module_name,module_tutor,compulsory,semester,year,cats_points,description,module_status)" +
                               "VALUES (@module_name,@module_tutor,@compulsory,@semester,@year,@cats_points,@description,@modulestatus)"; // use parameters to avoid sql injection
            using (var myCommand = new SqlCommand(addModule, myConnection))
            {
                myCommand.Parameters.AddWithValue("@year", yearddl.SelectedValue);
                myCommand.Parameters.AddWithValue("@module_name", module_nametext.Text);
                myCommand.Parameters.AddWithValue("@module_tutor", module_tutortext.Text);
                myCommand.Parameters.AddWithValue("@compulsory", compulsoryddl.SelectedValue);
                myCommand.Parameters.AddWithValue("@semester", semesterddl.SelectedValue);
                myCommand.Parameters.AddWithValue("@cats_points", cats_pointstext.Text);
                myCommand.Parameters.AddWithValue("@description", descriptiontext.Text);
                myCommand.Parameters.AddWithValue("@modulestatus", modulestatusddl.SelectedValue);
                try
                {
                    myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex) // catch specific exceptions
                { 
                    // do something with error here
                    // Response.Write(ex.Message); 
                }
            }
        }
        Response.Redirect("all-modules.aspx");
    }

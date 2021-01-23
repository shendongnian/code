    //validation checks
    else
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connStr);
        string questionSource = Session["QuestionSource"].ToString();
        string cmdText = "";
        MySqlCommand cmd; // <-- here
        if (questionSource.Equals("S"))
        {
            cmdText += @"SELECT COUNT(*) FROM questions Q
                        JOIN users U
                        ON Q.author_id=U.user_id
                        WHERE approved='Y'
                        AND role=1
                        AND module_id=@ModuleID";
            cmd = new MySqlCommand(cmdText, conn); // remove MySqlCommand  here
            cmd.Parameters.Add("@ModuleID", MySqlDbType.Int32);
            cmd.Parameters["@ModuleID"].Value = Convert.ToInt32(Session["TestModuleID"]);
        }
        else if (questionSource.Equals("U"))
        {
            cmdText += "SELECT COUNT(*) FROM questions WHERE approved='Y' AND module_id=@ModuleID AND author_id=@AuthorID;";
            cmd = new MySqlCommand(cmdText, conn); // remove MySqlCommand  here
            cmd.Parameters.Add("@ModuleID", MySqlDbType.Int32);
            cmd.Parameters["@ModuleID"].Value = Convert.ToInt32(Session["TestModuleID"]);
            cmd.Parameters.Add("@AuthorID", MySqlDbType.Int32);
            cmd.Parameters["@AuthorID"].Value = Convert.ToInt32(Session["UserID"]);
        }
        int noOfQuestionsAvailable = 0;
        int noOfQuestionsWanted = Convert.ToInt32(ddlNoOfQuestions.SelectedValue);
        try
        {
            conn.Open();
            noOfQuestionsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
            if (noOfQuestionsAvailable < noOfQuestionsWanted)
            {
                lblError.Text = "There are not enough questions available to create a test.";
            }
            else
            {
                Session["TestName"] = txtName.Text;
                Session["NoOfQuestions"] = ddlNoOfQuestions.SelectedValue;
                Session["QuestionSource"] = rblQuestionSource.SelectedValue;
                Session["TestModuleID"] = ddlModules.SelectedValue;
                Response.Redirect("~/create_test_b.aspx");
            }
        }
        catch
        {
            lblError.Text = "Database connection error - failed to get module details.";
        }
        finally
        {
            conn.Close();
        }
    }

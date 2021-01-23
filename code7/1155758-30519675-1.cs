    protected void CoursesListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ShowCourse")
            {
                Response.Redirect(e.CommandArgument.ToString());
            }
        }

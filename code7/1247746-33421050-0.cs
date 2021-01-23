     if (Roles.IsUserInRole(Login1.UserName , "Administor"))
        {
            Session["Admin"] = Login1.UserName;
            Response.Redirect("~/Admin/HomeAdmin.aspx");       
            //only run for admins
           
        }
        else if (Roles.IsUserInRole(Login1.UserName , "Professor"))
        {
            Session["Professor"] = Login1.UserName;
            Response.Redirect("~/Professor/HomeProfessor.aspx");
            //only run for professors
        }
        else if (Roles.IsUserInRole(Login1.UserName , "Student"))
        {
            Session["Student"] = Login1.UserName;
            Response.Redirect("~/Student/HomeStudent.aspx"); 
            //only run for students
        }

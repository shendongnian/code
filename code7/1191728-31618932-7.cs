        string username = TextBox1.Text;
            if (Roles.GetRolesForUser(username) == "LANDASSET")
            {
                 Response.Redirect("ManageLines.aspx");
            }
            else
            {
                 Response.Redirect("MainAdmin.aspx");
            }

            if (User.Identity.IsAuthenticated == true)
            {
                Response.Redirect("The Page you want");
            }
            else
                Response.Redirect("Login.aspx"); // redirect it to your login page

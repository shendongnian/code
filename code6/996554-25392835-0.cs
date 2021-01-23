    if (Page.IsValid)
    {
        if (!String.IsNullOrEmpty(AssignScreenName.Text) Profile.Screenname = AssignScreenName.Text;
        if (!String.IsNullOrEmpty(AssignBio.Text) Profile.Bio = AssignBio.Text;        
    }
    Profile.Save();
    Response.Redirect("MyProfile.aspx");
  

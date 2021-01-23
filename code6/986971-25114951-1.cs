      MembershipUserCollection users;
      public void Page_Load()
      {
         users = Membership.GetAllUsers();
         if (!IsPostBack)
         {
            // Bind users to ListBox.
            UsersListBox.DataSource = users;
            UsersListBox.DataBind();
         }
         // If a user is selected, show the properties for the selected user.
         if (UsersListBox.SelectedItem != null)
         {
              MembershipUser u = users[UsersListBox.SelectedItem.Value];
              EmailLabel.Text = u.Email;
              IsOnlineLabel.Text = u.IsOnline.ToString();
              LastLoginDateLabel.Text = u.LastLoginDate.ToString();
              CreationDateLabel.Text = u.CreationDate.ToString();
              LastActivityDateLabel.Text = u.LastActivityDate.ToString();
         }
     }     

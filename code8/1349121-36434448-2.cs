	private void btnUpdate_Click(object sender, EventArgs e)
	{
        // database context.
		UserContext UC  = new UserContext();
        
        // Get user.
		MyUser currentUser = UC.GetUserID(txtUserName.Text, txtPassword.Text);
        
        // now you can access userid from the User data-structure object.
		var id = currentUser.ID; 
	}

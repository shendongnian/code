    	public void WelcomeUser()
		{
			var userNames = new string[] { "jon", "todd", "bob" };
			var passwords = new int[] { 123, 321, 222 }; // integer passwords???
			var userLoc = Array.IndexOf(userNames, this.TxtUserName.Text);
			if(userLoc >= 0 && passwords[userLoc] == Convert.ToInt32(this.TxtPass.Text))
				MessageBox(String.Format("Welcome {0}!", userNames[userLoc]));
			else
				MessageBox("Bad username or password");
		}

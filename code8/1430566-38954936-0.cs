    else
    {
        string name = username.Text;
        string pass = password.Text;
 
        using (var db = new databaselinkDataContext())
        {
            // x.Id is an example, I don't know the schema of your table.
            var user = db.user.Where(x => x.Id == name).SingleOrDefault();
            if (user == null)
                throw new Exception(String.Format("User '{0}' does not exist in the database.", name);
            // Again user.Password is an example, I don't know the schema of your table.
            if (user.Password != pass)
                throw new Exception("Password is invalid.");
        }
    }

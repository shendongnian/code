    User result = conn.Query<User>(@"
                  SELECT * 
                  FROM User
                  WHERE Id = @Id
                  AND Password = @Password", 
                  new {  Id = id, Password = password }).FirstOrDefault();
    if(User != null) {
        MessageBox.Show("Hello!");
    }
    else {
        MessageBox.Show("wrong id or password");
    }

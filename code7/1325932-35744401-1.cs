    foreach (UserRecord rec in userlist) {
      if (null == rec) 
        MessageBox.Show("rec is null!");              // <- put a break point here
      else if (null == rec.Login)
        MessageBox.Show("rec.Login is null!");        // <- here
      else if (dictionary.ContainsKey(rec.Login))
        MessageBox.Show("rec.Login already exists!"); // <- and here 
      else
        dictionary.Add(rec.Login, rec.Group);
    }

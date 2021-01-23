    public void Add(Logged user)
    {
        if (!UserList.Any(x => x.Id == user.Id && x.UserName == user.UserName))
        {
            UserList.Add(user);
            ////Check the List for users
            UpdateView();
        }
        else
        {
            MessageBox.Show("Already exists!");
        }
    }

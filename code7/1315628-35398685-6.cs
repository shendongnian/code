    public void Add(Logged user)
    {
        if (!UserList.Any(x => x.Equals(user)))
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

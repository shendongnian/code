    public void setList<T>(List<T> list)
    {
        IList<Users> listUsers;
        if (typeof(T) == typeof(Users))
        {
            listUsers = (IList<Users>)list;
        }
        dataGrid1.ItemsSource = list;
    }

    public void DeleteUser(int id)
    {
        User delObj = Users.Where(u => u.UserId == id);
        Users.Remove(delObj);
        SaveChanges();
    }

    private void RemoveUser()
    {
        string clientId = GetClientId();
        lock(users)
        {
            users.Remove(users.FirstOrDefault(x => x.ClientId == clientId));
        }
    }

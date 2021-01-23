    public void CopyTo(UserModel target)
    {
        if (target == null)
            throw new ArgumentNullException();
        target.FirstName = this.FirstName;
        target.LastName = this.LastName;
        target.Username = this.Username;
        target.Id = this.Id;
    }

    public virtual bool Validate(string username, string password)
        {
            if (password == Password && username == Username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

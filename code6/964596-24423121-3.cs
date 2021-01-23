            public bool UserNameCheck(string alias)
        {
            if (UserExistCheck(alias) > 0)
            {
                throw new Exception("Alias Already exist");
            }
            else
            {
                return true;
            }
        }

     public bool ExistsByEmail(string email)
        {
            return
                _users.Any(
                    user => user.Email== email);
        }

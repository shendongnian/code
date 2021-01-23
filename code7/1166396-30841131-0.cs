        var usersToRemove = new List<SPUser>();
        foreach (var user in users) {
            string user_name = user.LoginName;
        
            string[]username = user_name.Split('\\');
            user_name = username[1].ToString().ToLower();
        
            if (!checkIfExists(user_name))
                usersToRemove.Add(user.LoginName);
        }
    }

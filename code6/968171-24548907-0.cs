    public void GetUserIdByCode(string userCode)
    {
        string clause = String.Format("Code=\"{0}\"", userCode);
        var userId = db.Users
			                .Where(clause)
                            .Select(u => u.Id)
                            .FirstOrDefault();    
    }

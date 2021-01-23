    public static bool IsOfficeEmail(string email)
    {
        using (var data = Database)
        {
    		return data.Offices.Any(a => a.Active && a.Email.Equals(email))
        }
    }

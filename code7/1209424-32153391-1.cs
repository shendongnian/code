    [WebMethod]
    public static List<UserDetails> GetDetails()
    {
        //Write your database logic here and add items in list
        List<UserDetails> details = new List<UserDetails>();
        details.Add(new UserDetails() { Location="aaaa", UserId="adv", UserName="fdfds"  });
        details.Add(new UserDetails() { Location = "bbbb", UserId = "hhhh", UserName = "aaaafds" });
        return details;
    }
 

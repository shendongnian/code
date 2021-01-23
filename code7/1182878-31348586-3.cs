    public User Get(string username, string password){
        var total = RealRepo.Get<User>(y => 
            y.Password == "12345" && 
            y.Username == "tester").Single();
        return total;
    }

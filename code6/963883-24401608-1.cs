    public void GetDetails()
    {
        Database db = new Database("localhost", "3306", "username", "password", "database");
        return db.GetCustomer(this.Id).Details;
    }

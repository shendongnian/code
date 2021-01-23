    using (IDbConnection connection = OpenConnection())
    {
        string query = @"SELECT Id,FirstName,LastName,
                        Address, City, PostalZip 
                        FROM Members";
        var result connection.Query<Member, Address, Member>(query, (mb, ad) =>
        {
            mb.Address = ad;
            return mb;
        },
        splitOn: "Address").SingleOrDefault();
    }

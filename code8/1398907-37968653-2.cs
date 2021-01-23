    using (IDbConnection connection = OpenConnection())
    {
        string query = @"SELECT Id,FirstName,LastName,
                        0 as splitterID, Address, City, PostalZip 
                        FROM Members";
        var result = connection.Query<Member, Place, Member>(query, (mb, pl) =>
        {
            mb.Address = pl;
            return mb;
        },
        splitOn: "splitterID");
    }

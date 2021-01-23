    using (var Conn = new SqlConnection(ConnectionString))
    {
        var dom = Conn.Reader<User>( "SELECT ID, NAME, FIRSTNAME FROM TABLE WHERE UserID=@UserID",
        p =>
        {
            p.AddWithValue("@UserID", UserID);
        },
        dr =>
        {
            return new User()
            {
                NAME = dr["NAME"].ToString(),
                FIRSTNAME = dr["FIRSTNAME"].ToString()
            };
        }
        ).ToList();
    }

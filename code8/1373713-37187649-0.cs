    //@code nvarchar(20),
    //@type nvarchar(20),
    //@condition nvarchar(1000),
    //@leavedays nvarchar(50)
    SqlParameter id = new SqlParameter("@id", SqlDbType.VarChar);
    SqlParameter code = new SqlParameter("@code", SqlDbType.VarChar);
    SqlParameter type = new SqlParameter("@type", SqlDbType.VarChar);
    SqlParameter conditions = new SqlParameter("@conditions", SqlDbType.VarChar);
    SqlParameter No_ofleaves = new SqlParameter("@No_ofleaves", SqlDbType.VarChar);

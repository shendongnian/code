    public static double calculateTotalPrice(int reserveringId)
    {
        double total=0;
        SqlCommand comm =  sqlCrud.returnSqlCommand("select g.prijs from gerechten g inner join besteld b on b.gerechtId=g.gerechtId where b.reserveringId='"+reserveringId+"'");
        SqlDataReader dt = comm.ExecuteReader();
        if (dt.HasRows)
        {
            while (dt.Read())
            {
                total += dt.GetDouble(0);
            }
        }
        return total;
    }

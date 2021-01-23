    sqlcom.Parameters.Add("@name", SqlDbType.VarChar).Value =
           string.IsNullOrWhiteSpace(Name.Text) ? DBNull.Value : (object)Name.Text;
    sqlcom.Parameters.Add("@surname", SqlDbType.VarChar).Value = 
           string.IsNullOrWhiteSpace(Surname.Text) ? DBNull.Value : (object)Surname.Text;
    sqlcom.Parameters.Add("@city", SqlDbType.VarChar).Value = 
           string.IsNullOrWhiteSpace(City.Text) ? DBNull.Value : (object)City.Text;
